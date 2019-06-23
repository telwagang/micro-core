using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.Management;
using Micro_core.IBusinessLayer;

namespace Micro_core.BusinessLayer
{
    public class EmailLayer : IEmailLayer
    {
        public EmailLayer()
        {
        }

        public void SendToNewUserSignUp(Staff staf)
        {
            
            var email = new MicroEmail
            {
                Email = staf.email,
                UserType = MicroUserType.Staff,
                SubJect = "Staff Complete Sign up",
                ObjectId = staf.ID
            };

            // change this url to a system variables 
            var url = $"http://localhost:5000/signup/{staf.UserID}";

            var content = @"<div class='card'><div class='card-body'>
        <h4 class='card-title'>Dear @name,</h4>
        <p class='card-text'>Welcome Micro Systems. click the button below to finish your sing up process and verfy your email account. 
            <b> this account will be further used to send notifications and remainder on from micro systems. </p>
    </div><div class='card-body'><a href='@url' class='card-link' target='_blank'>Click here to finish Sign up</a>
    </div></div>";

            content = content.Replace("@name", staf.First_Name + ' '+ staf.Last_Name );
            content = content.Replace("@url", url);
            email.Content = content;

            email.save();
        }
    }
}