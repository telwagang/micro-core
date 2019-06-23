using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using API.DataModels.Management;
using API.Interfaces;

namespace API.DataModels.Hisa
{
    public class HisaLimit : IBaseModel
    {
        [NotMapped]
        public int Id
        {
            get;
            set;
        }
        [Key, ForeignKey("Company")]
        public int CompanyId { get; set; }
        public int Hisa { get; set; }
        public int Amount { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public virtual Company Company { get; set; }
    }
}