using System.ComponentModel;
using System.Linq;
using Micro_core.DataLayer.Models.Emuns;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Micro_core.DataLayer.Models.Management
{
    public class MicroEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string SubJect { get; set; }
        public string cc { get; set; }
        public string Content { get; set; }
        public MicroEmailType EmailType { get; set; }

        public MicroUserType UserType { get; set; }
        public int ObjectId { get; set; }

        [DefaultValue(false)]
        public bool IsSent { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }


        public void save()
        {
            using (var ctx = new MicroContext())
            {
                var old = ctx.Email.
                AsNoTracking().
                FirstOrDefault(x => x.Id == Id);

                if (old == null)
                {
                    ctx.Email.Add(this);
                }
                else
                {
                    ctx.Entry(this).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }

        public static bool SendToNewUserSignUp(HttpContext context, int staffId)
        {

            var staf = Staff.GetById(staffId);
            if (staf == null) return false;

            var email = new MicroEmail
            {
                Email = staf.email,
                UserType = MicroUserType.Staff,
                SubJect = "Staff Complete Sign up",
                ObjectId = staffId
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

            return true;
        }
    }
}