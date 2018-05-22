using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Micro_core.Models.Hisa
{
    public class HisaLimit
    {
        [Key, ForeignKey("Company")]
        public int CompanyId { get; set; }
        public int Hisa { get; set; }
        public int Amount { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public virtual Company Company { get; set; }
    }
}