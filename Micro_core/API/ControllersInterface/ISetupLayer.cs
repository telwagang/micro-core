using System.Collections.Generic;
using API.DataModels.Loan;
using API.DataModels.Management;


namespace API.ControllersInterface
{
    public interface ISetupLayer
    {
        void SetCompany(Company c);
        Company GetCompany();  
        void SetStaff(Staff s); 

        Staff GetStaff(int id);

        List<Staff> GetStaff(); 
        Interest GetInterest(int id); 
        void SetInterest(interestViewModel ivm); 
        List<interestViewModel> GetInterest(); 
    }
}