using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Micro_core.DataLayer.Models.Management;

namespace Micro_core.Models.Loan
{
    public class Loan
    {
        public Loan()
        {
            LoanStatus = new List<LoanStatus>();
            payments = new List<Payment>();
        }

       [Key]
        public string LoanId { get; set; }
        public string CustomerId { get; set; }
        public int StaffId { get; set; }
        public int Duration { get; set; }
        public int Amount { get; set; }
        public int ReturnAmount { get; set; }
        public DateTime Date_Sumbit { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
        public virtual LoanApplicantion LoanApplication { get; set; }
        public virtual ICollection<Payment> payments { get; set; }
        public virtual ICollection<LoanStatus> LoanStatus { get; set; }
        public virtual LoanDone LoanDone { get; set; }
        public virtual LoanBalance LoanBalance { get; set; }
    }
}