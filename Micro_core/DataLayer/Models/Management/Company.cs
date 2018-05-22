using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Models.Management;
using Micro_core.Models.Hisa;
using Micro_core.Models.Loan;
using Microsoft.EntityFrameworkCore;

namespace Micro_core.Models
{
    public class Company
    {
        #region Properties
        public Company()
        {
            Staff = new List<Staff>();
            Customer = new List<Customer>();
            Interest = new List<Interest>();
        }


        [Key]
        public int CompanyId { get; set; }
        public int Tin_no { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime Date { get; set; }
        public int KeyValue { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Interest> Interest { get; set; }
        public virtual HisaLimit Hisalimit { get; set; }
        public virtual LoanLimit loanLimit { get; set; }

        #endregion

        public void save()
        {
            using (var ctx = new MicroContext())
            {
                var old = ctx.Company.
                AsNoTracking().
                FirstOrDefault(x => x.CompanyId == CompanyId);

                if (old == null)
                {
                    if (Date == default(DateTime))
                    {
                        Date = DateTime.UtcNow;
                    }
                    CompanyId =0;
                    ctx.Company.Add(this);
                }else{
                    ctx.Entry(this).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }

        public static Company GetCompany(){
            using (var ctx = new MicroContext())
            {
                return ctx.Company.FirstOrDefault();
            }
        }
    }
}