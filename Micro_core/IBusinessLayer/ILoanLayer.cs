using System.Collections.Generic;
using Micro_core.DataLayer.Models;
using Micro_core.Models;

namespace Micro_core.IBusinessLayer
{
    public interface ILoanLayer
    {
         List<LoanPending> GetPending(int companyId);
         void NewLoanApplication(LoanApplication data); 

         void PayLoan(paymentViewModel pvm); 
    }
}