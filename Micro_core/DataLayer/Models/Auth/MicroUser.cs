using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.Management;
using Micro_core.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro_core.DataLayer.Models.Auth
{
    public class MicroUser
    {
        
        public MicroUser()
        {
        }
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password
        {
            get; set;
            // get { return Password; }
            // set
            // {
            //     if (!string.IsNullOrEmpty(value))
            //     {
            //         Password = value;
            //         //Password = BCrypt.Net.BCrypt.HashPassword(value, BCrypt.Net.BCrypt.GenerateSalt());
            //     }
            // }
        }
        [NotMapped]
        public string EncyptPassword { get; set; }
        public string AccessToken { get; set; }
        public MicroUserType Type { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LockOutUntill { get; set; }
        public bool LockOut { get; set; }
        public bool Deleted { get; set; }

        public void save()
        {
            using (var ctx = new MicroContext())
            {
                var old = ctx.User.
                AsNoTracking().
                FirstOrDefault(x => x.Id == Id);

                if (old == null)
                {
                    ctx.User.Add(this);
                }
                else
                {
                    ctx.Entry(this).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }

        public LoginViewModel ReturnToClient()
        {
            var staff = Staff.GetByApiKey(Id.ToString());
            return new LoginViewModel
            {
                Username = Username,
                id = Id,
                ApiKey = AccessToken,
                Type = Type,
                TypeId =  staff?.ID ?? 0,
                CompanyId =  staff?.CompanyId ?? 0
            };
        }

        public static MicroUser GetByUsername(string username)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.User.FirstOrDefault(x => x.Username == username &&
                 !x.Deleted);
            }
        }

        internal static object CheckByToken(string token)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.User.Any(x => x.AccessToken == token);
            }
        }
    }
}