using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Micro_core.DataLayer.Models;
using API.Interfaces;
using API.DataModels.Management;

namespace API.DataModels.Loan
{
    public class Interest : IBaseModel
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int StaffId { get; set; }
        public int Duration { get; set; }
        public decimal Rate { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }


        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        public ICollection<LoanLimit> loanLimits
        {
            get;
            set;
        }

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
        public void addLoanLimit(LoanLimit lm)
        {
            using (var ctx = new MicroContext())
            {
                var old = ctx.LoanLimit.
                AsNoTracking().
                FirstOrDefault(x => x.Id == lm.Id);

                lm.InterestId = ID;
                if (old == null)
                {

                    ctx.LoanLimit.Add(lm);
                }
                else
                {
                    ctx.Entry(lm).State = EntityState.Modified;
                }
                ctx.SaveChanges();


            }
        }
        public static Interest GetById(int id)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Interest.FirstOrDefault(x => x.ID == id & !x.Deleted);
            }
        }


        public LoanLimit GetLoanLimit()
        {
            using (var ctx = new MicroContext())
            {
                return ctx.LoanLimit.FirstOrDefault(x => x.InterestId == ID && !x.Deleted);
            }
        }
        internal static List<interestViewModel> All()
        {
            using (var ctx = new MicroContext())
            {
                return (from i in ctx.Interest
                        join l in ctx.LoanLimit on i.Id equals l.InterestId
                        into lm
                        from lmdefualt in lm.DefaultIfEmpty()
                        select new interestViewModel
                        {
                            CompanyId = i.CompanyId,
                            ID = i.ID,
                            Rate = i.Rate,
                            Duration = i.Duration,
                            loanLimitId = lmdefualt != null ? lmdefualt.Id : 0,
                            LimitAmount = lmdefualt  != null ?  lmdefualt.LimitAmount : 0
                        }).ToList();
            }
        }
    }
}