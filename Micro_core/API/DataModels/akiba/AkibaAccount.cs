using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using API.DataModels.Management;
using API.Enums;
using API.Interfaces;
using Micro_core.Models;

namespace API.DataModels.akiba
{
    public class AkibaAccount : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public MicroAkibaType TranscationType { get; set; }

        public decimal TranscationAmount { get; set; }

        public decimal Balance { get; set; }

        public DateTime Date { get; set; }

        [DefaultValue(false)]
        public bool Deleted {get; set;}


        public  Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
    }
}