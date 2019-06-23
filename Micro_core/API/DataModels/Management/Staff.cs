using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using API.Interfaces;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Models.akiba;
using Micro_core.DataLayer.Models.Management;
using Micro_core.Models;
using Micro_core.Models.akiba;
using Micro_core.Models.Hisa;
using Micro_core.Models.Loan;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace API.DataModels.Management
{
    public class Staff : IBaseModel
    {

        public Staff()
        {
            //loan = new List<Loan.Loan>();
            Akiba = new List<AkibaAccount>();
           
            Customer = new List<Customer>();
            Interest = new List<Interest>();

        }

        #region Properties 

        public int Id { get; set; }

        //[ForeignKey("User")]
        public string UserID { get; set; }

        public int CompanyId { get; set; }

        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Position { get; set; }


        public DateTime birthdate { get; set; }
        public string email { get; set; }
        public string Mobile_Number { get; set; }
        public DateTime Date { get; set; }


        [DefaultValue(false)]
        public bool Deleted { get; set; }

        // public virtual ApplicationUser User { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Loan> loan { get; set; }
        public virtual ICollection<AkibaAccount> Akiba { get; set; }

        public virtual ICollection<Reference> reference { get; set; }
        public virtual ICollection<HisaHistory> HisaHistory { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Interest> Interest { get; set; }
        
        #endregion

        public void save()
        {
            using (var ctx = new MicroContext())
            {
                var old = ctx.Staff.
                AsNoTracking().
                FirstOrDefault(x => x.ID == ID);

                if (old == null)
                {
                    UserID = Guid.NewGuid().ToString("N").Substring(10, 16).ToUpper();
                    ID = 0;                     
                    if (Date == default(DateTime))
                    {
                        Date = DateTime.UtcNow;
                    }
                    ctx.Staff.Add(this);
                }
                else
                {
                    ctx.Entry(this).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }

        }
        public static List<Staff> All()
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Staff.Where(x => !x.Deleted).ToList();
            }
        }

        public static Staff GetById(int id)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Staff.FirstOrDefault(x => x.ID == id & !x.Deleted);
            }
        }

        public static Staff GetByApiKey(string key){
            using (var ctx = new MicroContext())
            {
                return ctx.Staff.FirstOrDefault(x => x.UserID == key 
                && !x.Deleted);
            }
        }
        
       
    }
}