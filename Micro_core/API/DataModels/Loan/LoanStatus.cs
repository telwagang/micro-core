using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interface;

namespace API.DataModels.Loan
{
    public class LoanStatus : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Loan")]
        public string LoanId { get; set; }
        public decimal Monthly { get; set; }
        public DateTime Nextpayday { get; set; }
        [DefaultValue(false)]
        public bool paid {get; set;}
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public virtual Loans Loan { get; set; }


    }
}