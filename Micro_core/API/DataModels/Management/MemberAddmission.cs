using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using API.Interfaces;

namespace Micro_core.Models.Management
{
    public class MemberAddmission:IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public virtual Customer customer { get; set; }
    }
}