using Micro_core.DataLayer.Models.Management;

namespace Micro_core.IBusinessLayer
{
    public interface IEmailLayer
    {
         void SendToNewUserSignUp(Staff staff); 
    }
}