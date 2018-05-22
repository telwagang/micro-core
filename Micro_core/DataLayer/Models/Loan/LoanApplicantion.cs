using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Micro_core.Models.Loan
{
    public class LoanApplicantion
    {
        public int Id {get; set ;}
        [Key, ForeignKey("Loan")]
        public string LoanId { get; set; }
        public int StaffId  { get; set; }
        public bool Approved { get; set; }
        public DateTime Date { get; set; }
       
        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public virtual Loan Loan { get; set; }
        
    }
}