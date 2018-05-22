using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Micro_core.Models.Loan
{
    public class LoanStatus
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Loan")]
        public string LoanId { get; set; }
        public int Monthly { get; set; }
        public DateTime Nextpayday { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public virtual Loan Loan { get; set; }
    }
}