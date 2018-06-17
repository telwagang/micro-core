using System;
using System.Collections.Generic;
using System.Linq;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Models;
using Micro_core.DataLayer.Models.Base;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.Management;
using Micro_core.IBusinessLayer;
using Micro_core.Models;
using Micro_core.Models.Loan;
using Microsoft.EntityFrameworkCore;

namespace Micro_core.BusinessLayer
{
    internal class LoanLayer : ILoanLayer
    {

        private readonly MicroContext _microContext;
        private readonly IUserLayer _customerLayer;
        private readonly IAkibaLayer _akibaLayer; 
        private static readonly object locker = new object();
        public LoanLayer(MicroContext microContext, IUserLayer userLayer, IAkibaLayer akibalayer)
        {
            _microContext = microContext;
            _customerLayer = userLayer;
            _akibaLayer = akibalayer;
        }
        public List<LoanPending> GetPending(int companyId)
        {
            return Loan.GetLoanStatus();
        }

        public void NewLoanApplication(LoanApplication data)
        {
            using (_microContext)
            using (var tans = _microContext.Database.BeginTransaction())
            {

                try
                {
                    if (!_customerLayer.ValidMembershipPeriod(data.customerid))
                        throw new MicroException("Customer hasn't been a member for more than 3 month");

                    var LoanId = Guid.NewGuid().ToString("D").Substring(14, 14).ToUpper();

                    var customer = Customer.GetById(data.customerid);
                    if (customer == null) throw new MicroException("Customer does not exist");

                    var staff = Staff.GetById(data.staffId);
                    if (staff == null) throw new MicroException("Current user does not exist");


                    var inter = Interest.GetById(data.hisa);
                    if (inter == null) throw new MicroException("Couldnt find the selected Hisa");


                    var ongoingLoans = GetByCustomer(data.customerid);
                    if (ongoingLoans.Where(x => x.Status == MicroLoanStatus.Active).Count() > 3)
                        throw new MicroException("User has more than 3 active Loans.");


                    if (ongoingLoans.Any(x => x.Date_Sumbit == data.date && x.Amount == data.Amount))
                        throw new MicroException("Cannot apply for a loan twice on the same day");
                    // add more conditions for the loans. 

                    var repayAmount = CalculateLoan(inter, data.Amount);
                    if (repayAmount != data.RepayAmount) throw new MicroException($"Loan Repayable amount mis calculation. From {data.RepayAmount}. System {repayAmount}");


                    var loanLimit = inter.GetLoanLimit();
                    if (loanLimit == null) throw new MicroException("The Interest selected has no loan limit. set up the loan limit first");


                    if (data.Amount < loanLimit.LimitAmount)
                        throw new MicroException($"The Customer requested Loan `{data.Amount}`is more than the loan cap {loanLimit.LimitAmount} for this interest ");


                    var loan = new Loan
                    {
                        StaffId = staff.ID,
                        LoanId = LoanId,
                        Status = MicroLoanStatus.Pending,
                        ActionType = MicroLoanType.Application,
                        Duration = inter.Duration,
                        ReturnAmount = repayAmount,
                        Amount = data.Amount,
                        Date_Sumbit = data.date
                    };

                    _microContext.Loan.Add(loan);

                    var Monthly = repayAmount / inter.Duration;

                    var status = new LoanStatus
                    {
                        LoanId = loan.LoanId,
                        Monthly = Monthly,
                        Nextpayday = data.date.AddDays(28)
                    };

                    _microContext.LoanStatus.Add(status);
                    _microContext.SaveChanges();

                    tans.Commit();
                }
                catch (Exception ex)
                {
                    tans.Rollback();

                    throw ex;
                }

            }

        }
        public void PayLoan(paymentViewModel pvm)
        {
            using (_microContext)
            using (var tans = _microContext.Database.BeginTransaction())
            {

                try
                {
                    var customer = Customer.GetById(pvm.CustomerId);
                    if (customer == null) throw new MicroException("Customer does not exist");

                    var staff = Staff.GetById(pvm.StaffId);
                    if (staff == null) throw new MicroException("Current user does not exist");

                    var payableLoan = LoanStatus.GetNextPayDay(pvm.LoanId) ??
                    new LoanStatus { LoanId = pvm.LoanId };

                    var loan = Loan.GetByLoanId(pvm.LoanId);
                    if (loan == null) throw new MicroException($"Customer has no loan :{pvm.LoanId} yet");

                    if (loan.Status == MicroLoanStatus.Decline)
                        throw new MicroException($"This loan was never approved");

                    if (loan.Status == MicroLoanStatus.Done && loan.ReturnAmount == 0)
                        throw new MicroException("This loan had been complated already");

                    if (loan.Status == MicroLoanStatus.Pending)
                        throw new MicroException("This loan hasn't been approved yet");

                    var payments = Loan.GetLastPayment(pvm.LoanId) ??
                                 new Loan { LoanId = loan.LoanId, 
                                     ActionType = MicroLoanType.Payment,
                                  Status = MicroLoanStatus.Active,
                                  ReturnAmount = loan.ReturnAmount};

                    var balance = pvm.AmountPaid - payableLoan.Monthly;

                    
                    // update payments 
                    payments.ReturnAmount -= pvm.AmountPaid;
                    payments.LoanId = ""; 
                    payments.ParentId = loan.LoanId;
                    payments.Amount = pvm.AmountPaid;

                    
  
                    // update loan status 
                    loan.Status = payments.ReturnAmount <= 0 
                    ? MicroLoanStatus.Done 
                    : MicroLoanStatus.Active;


                    if(loan.Status == MicroLoanStatus.Done)
                    {
                        if(loan.ReturnAmount < 0){
                       _akibaLayer.UpdateSavingAccount(new akibaViewModel{
                           Amount = (int)Math.Abs(payments.ReturnAmount),
                           customerId = payments.CustomerId,
                           ctORdt = MicroAkibaType.Deposit,
                           createdDate = pvm.Date
                       });}


                    }
                    else
                    {
                        if (balance == 0)
                        {
                            payableLoan.Nextpayday.AddDays(28);
                            payableLoan.ID = 0;
                        }
                        else if (balance > 0)
                        {
                            var times = Math.Floor(Math.Round(balance / payableLoan.Monthly, MidpointRounding.AwayFromZero));
                            payableLoan.Nextpayday.AddDays(28 * times > 1 ? (int)times : 1);
                            payableLoan.ID = 0;
                        }
                        
                        loan.saveStatus(_microContext, payableLoan);

                    }
                    
                    payments.save(_microContext);
                    loan.save(_microContext); 
                    
                    _microContext.SaveChanges();
                    tans.Commit();
                }
                catch (Exception ex)
                {
                    tans.Rollback();
                    throw ex;
                }
            }
        }
        public List<Loan> GetByCustomer(string id)
        {
            using (_microContext)
            {
                return (from l in _microContext.Loan
                        where l.ActionType == MicroLoanType.Application
                        && !l.Deleted
                       && l.Status != MicroLoanStatus.Done && l.CustomerId == id
                        select l).ToList();
            }
        }

        public List<Loan> GetLoansForUser(string id)
        {
            using (_microContext)
            {
                return _microContext.Loan.Where(x => x.ActionType == MicroLoanType.Application).ToList();

            }
        }
 
        public decimal CalculateLoan(Interest i, decimal amount)
        {
            return (decimal)((i.Rate / 100 * amount) + amount) * i.Duration;
        }


    }
}