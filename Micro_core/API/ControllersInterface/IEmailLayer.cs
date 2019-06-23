using API.DataModels.Management;

namespace API.ControllersInterface
{
    public interface IEmailLayer
    {
         void SendToNewUserSignUp(Staff staff); 
    }
}