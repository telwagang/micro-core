using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Micro_core.DataLayer;

namespace Micro_core.Models.Loan
{
    public class LoanStatus
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Loan")]
        public string LoanId { get; set; }
        public decimal Monthly { get; set; }
        public DateTime Nextpayday { get; set; }
        [DefaultValue(false)]
        public bool paid {get; set;}
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public virtual Loan Loan { get; set; }

        internal static LoanStatus GetNextPayDay(string loanId)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.LoanStatus.Where(x=> x.LoanId == loanId).OrderByDescending(x=> x.Nextpayday).FirstOrDefault(); 
            }
        }
    }
}