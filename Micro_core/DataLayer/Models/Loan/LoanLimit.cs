using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Micro_core.DataLayer;

namespace Micro_core.Models.Loan
{
    public class LoanLimit
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Interst")]
        public int InterestId {get; set;}
        public decimal LimitAmount { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public virtual Interest Interst {get; set;}

        internal static LoanLimit GetById(int loanLimitId)
        {
            using(var ctx = new MicroContext()){
                return ctx.LoanLimit.FirstOrDefault(x=> x.Id == loanLimitId && !x.Deleted); 
            }
        }
    }
}