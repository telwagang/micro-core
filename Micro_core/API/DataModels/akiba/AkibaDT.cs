﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Micro_core.DataLayer.Models.Management;

namespace Micro_core.Models
{
    public class AkibaDT
    {
        public int ID { get; set; }
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        [ForeignKey("Akiba")]
        public string AkibaId { get; set; }
        public int DT_Amount { get; set; }
        public DateTime date { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Akiba Akiba { get; set; }

    }
}