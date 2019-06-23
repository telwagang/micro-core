using System.Collections.Generic;
using API.DataModels.Loan;
using API.DataModels.Management;
using Micro_core.DataLayer.Models;
using Micro_core.DataLayer.Models.Management;
using Micro_core.IBusinessLayer;
using Micro_core.Models;
using Micro_core.Models.Loan;

namespace Micro_core.BusinessLayer
{
    public class SetUpLayer : ISetupLayer
    {
        private readonly IEmailLayer _emailLayer; 
        public SetUpLayer(IEmailLayer emailLayer)
        {
            _emailLayer  = emailLayer; 
        }

        public Company GetCompany()
        {
            return Company.GetCompany();
        }

        public List<interestViewModel> GetInterest()
        {
            return Interest.All();
        }

        public Interest GetInterest(int id)
        {
            return Interest.GetById(id); 
        }

        public Staff GetStaff(int id)
        {
            return Staff.GetById(id); 
        }

        public List<Staff> GetStaff()
        {
           return Staff.All(); 
        }

        public void SetCompany(Company c)
        {
            c.save(); 
        }

        public void SetInterest(interestViewModel inter)
        {
            var interest = Interest.GetById(inter.Id) 
            ?? new Interest{
                Duration = inter.Duration,
                Rate = inter.Rate,
                StaffId = inter.StaffId,
                CompanyId = inter.CompanyId
            };

            interest.save();

            if (inter.LimitAmount != 0)
            {
                var lm = LoanLimit.GetById(inter.loanLimitId) ??
                new LoanLimit
                {
                    InterestId = inter.Id
                };

                lm.LimitAmount = inter.LimitAmount;

                inter.addLoanLimit(lm);
            }
        }

        public void SetStaff(Staff s)
        {
            s.save(); 
            
            _emailLayer.SendToNewUserSignUp(s); 
            
        }
    }
}