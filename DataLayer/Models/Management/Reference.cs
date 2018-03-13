using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Micro_core.Models
{
    public class Reference
    {
        public int ID { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }  
    }
}