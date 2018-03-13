using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Micro_core.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Micro_core.Models.Loan
{
    public class Interest
    {
        public int ID { get; set; }
        public int? CompanyId { get; set; }
        public int StaffId { get; set; }
        public int Duration { get; set; }
        public double Rate { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }


        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        public void save()
        {
            using (var ctx = new MicroContext())
            {
                var old = ctx.Staff.
                AsNoTracking().
                FirstOrDefault(x => x.ID == ID);

                if (old == null)
                {
                    ctx.Interest.Add(this);
                }
                else
                {
                    ctx.Entry(this).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }

        public static Interest GetById(int id)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Interest.FirstOrDefault(x=> x.ID == id & !x.Deleted); 
            }
        }

        internal static List<Interest>  All()
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Interest.Where(x=>  !x.Deleted).ToList(); 
            }
        }
    }
}