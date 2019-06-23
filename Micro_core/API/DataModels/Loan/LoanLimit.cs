﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using API.DataModels.Loan;
using API.Interfaces;
using Micro_core.DataLayer;

namespace API.DataModels.Loan
{
    public class LoanLimit : IBaseModel
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