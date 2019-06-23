using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using API.Interfaces;

namespace API.DataModels.Management
{
    public class Reference :IBaseModel
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }  
    }
}