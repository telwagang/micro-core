﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.Models.Loan;

namespace Micro_core.DataLayer.Models
{
    public class AkibaMultipleViewModel
    {
        public string CustomerId {get; set;}
        public string  Name { get; set; }
        public decimal Balance { get; set; }
        public DateTime? WitdrawDate { get; set; }     
        public DateTime? DepositDate { get; set; }
        public decimal? withdrawAmount { get; set; }
        public decimal? DepositAmount {get; set;}

    }
    public class akibaViewModel
    {
        [Required]
        public string customerId { get; set; }
        [Required]
        public int staffId { get; set; }
        [Required]
        public string AkibaId { get; set; }
        [Required]
       
        public MicroAkibaType ctORdt { get; set; }

        public int Amount { get; set; }
        
        public DateTime? createdDate {get; set;}
    }
    public class hisaViewModel
    {
        [Display(Name = "Amount of shares")]
        [ReadOnly(true)]
        public int NoHisa { get; set; }

        [Display(Name = "Totaly cash in hand")]
        public int amount { get; set; }

        [Timestamp]
        public DateTime date { get; set; }

    }
    public class paymentViewModel
    {
        public string CustomerId { get; set; }
        public string LoanId { get; set; }
        public int StaffId { get; set;  }
        public decimal AmountPaid { get; set; }
        public DateTime Date { get; set; }

    }

    public class name
    {
        public string Fullname { get; set; }
    }

    public class activityViewModel
    {
        [Display(Name="No")]
        public int number { get; set; }
        [Display(Name ="Customer Name")]
        public string Customer_name { get; set; }

        [Display(Name ="Akiba ID")]
        public string  akiba_id { get; set; }

        [Display(Name ="Staff Added")]
        public string  staff { get; set; }
        
        [Display(Name ="Amount")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public int amount { get; set; }

        [Display(Name ="Date Add")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
    }

    public class nextpaydayModel
    {
        [Display(Name = "No")]
        public int number { get; set; }

        [Display(Name = "Customer Name")]
        public string Customer_name { get; set; }

        [Display(Name = "Last Desposite Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime LDD { get; set; }

        [Display(Name = "Last Desposite Amount")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public int LDA { get; set; }

        [Display(Name = "Next Desposite Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime NDD { get; set; }

        [Display(Name = "Next Desposite Amount")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public int NDA { get; set; }
    }

    [NotMapped]
    public class interestViewModel: Interest
    {
       public int loanLimitId { get; set; }
       public decimal LimitAmount {get;set;}

    }
    public class hisa
    {
        [Display(Name = "Customer name")]
        public string Customer_name { get; set; }

        [Display(Name = "User Id ")]
        public string id { get; set; }

        [Display(Name = "Rate in %")]
        public double rate { get; set; }
    }
    public class proccesloan
    {
        public int bank_amount {get; set;}
        public int loan_amount { get; set; }
        public double rate { get; set; }
        public int returnamount { get; set; }
        public int duration { get; set; }
        public string loanid { get; set; }
    }
}