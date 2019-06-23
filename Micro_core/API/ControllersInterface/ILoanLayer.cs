using System.Collections.Generic;


namespace API.ControllersInterface
{
    public interface ILoanLayer
    {
         List<LoanPending> GetPending(int companyId);
         void NewLoanApplication(LoanApplication data); 

         void PayLoan(paymentViewModel pvm); 
    }
}