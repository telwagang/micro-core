using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;

namespace API.DataModels.Hisa
{
    [Table(nameof(MicroContext.Mainhisa))]
    public class MainHisa : IBaseModel
    {
        public MainHisa()
        {
            HisaHistory = new List<HisaHistory>();
        }
        [NotMapped]
        public int Id
        {
            get;
            set;
        }
        [Key,ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public int NoHisa { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public  Customer Customer { get; set; }
        public virtual ICollection<HisaHistory> HisaHistory { get; set; }
    }
}