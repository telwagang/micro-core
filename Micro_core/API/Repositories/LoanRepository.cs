using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataModels.Loan;
using API.Enums;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        readonly IBaseRepository _microContext;

        public LoanRepository(IBaseRepository baseRepository)
        {
            _microContext = baseRepository; 
        }

        public async Task<Loans> GetByLoanId(string loanId)
        {
            return await _microContext
                ._microContext.Loan
                .FirstOrDefaultAsync(x =>
                                     x.LoanId == loanId 
                                     && !x.Deleted);
        }

        public Task<Loans> GetLastByLoanId(string loanId)
        {
            throw new NotImplementedException();
        }

        public async Task<Loans> GetLastPayment(string loanId)
        {
            return await _microContext._microContext
                                      .Loan.Where(x => x.ParentId == loanId && x.ActionType == MicroLoanType.Payment).OrderByDescending(x => x.Date_Sumbit)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Loans>> GetLoanByCompany()
        {
            return await _microContext._microContext.Loan.Where
                                      (x => x.ActionType == MicroLoanType.Application
                                       && !x.Deleted).ToListAsync();
        }

        public async Task<Loans> GetLoanFee(string id)
        {
            return await _microContext._microContext.Loan
                                      .FirstOrDefaultAsync(x => x.ParentId == id
                                                           && x.ActionType == MicroLoanType.Application && !x.Deleted);
        }

        public async Task<LoanLimit> GetLoanLimitByLoanId(int loanId)
        {
            return await _microContext.GetById<LoanLimit>(loanId); 
        }

        public async Task<List<LoanLimit>> GetLoanLimitsByInterest(int id)
        {
            return await _microContext._microContext.LoanLimit
                                      .Where(x => x.InterestId == id && !x.Deleted).ToListAsync();
        }

        public async Task<List<Loans>> GetLoanStatus()
        {
            var d = await GetLoanByCompany();

            return d.Where(x=> x.Status != MicroLoanStatus.Done || x.Status != MicroLoanStatus.Active).ToList();

        }

        public async Task<LoanStatus> GetNextPayDay(string loanId)
        {
            return await _microContext._microContext.LoanStatus
                                      .Where(x => x.LoanId == loanId)
                                      .OrderByDescending(x => x.Nextpayday).FirstOrDefaultAsync();
        }
    
        public async Task SavaLoanLimit(LoanLimit lt)
        {
            await _microContext.AddOrUpdate(lt); 
        }

       
        public async Task SaveOrUpdate(Loans loan)
        {
            var old =  await _microContext._microContext.Loan.
                                   AsNoTracking().FirstOrDefaultAsync(x => x.LoanId == loan.LoanId);

            if (old == null)
            {
                await _microContext._microContext.Loan.AddAsync(loan);
            }
            else
            {
                _microContext._microContext.Entry(loan).State = EntityState.Modified;
            }
            await _microContext._microContext.SaveChangesAsync();
        }

        public async Task SaveStatus(LoanStatus ls)
        {
            await _microContext.AddOrUpdate(ls); 
        }
    }
}
