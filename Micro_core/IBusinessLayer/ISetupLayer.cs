using System.Collections.Generic;
using Micro_core.DataLayer.Models;
using Micro_core.DataLayer.Models.Management;
using Micro_core.Models;
using Micro_core.Models.Loan;

namespace Micro_core.IBusinessLayer
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