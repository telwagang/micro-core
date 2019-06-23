using System.ComponentModel;
using System.Linq;
using API.Interfaces;
using Micro_core.DataLayer.Models.Emuns;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace API.DataModels.Management
{
    public class MicroEmail : IBaseModel
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

    }
}