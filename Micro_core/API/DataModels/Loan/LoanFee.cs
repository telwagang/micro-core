using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using API.Interfaces;

namespace API.DataModels.Loan
{
    public class LoanFee : IBaseModel
    {
        [Key]
        public int Id {get; set; }

        [ForeignKey("Loan")]
        public string LoanId { get; set; }
        public decimal Fee { get; set; }

       [DefaultValue(false)]
        public bool Deleted { get; set; }
        public virtual Loans Loan { get; set; }
    }
}