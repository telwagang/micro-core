using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Micro_core.Models.Loan
{
    public class LoanBalance
    {
        [Key,ForeignKey("Loan")]
        public string LoanId { get; set; }
        public int Balance { get; set; }

       [DefaultValue(false)]
        public bool Deleted { get; set; }
        public virtual Loan Loan { get; set; }
    }
}