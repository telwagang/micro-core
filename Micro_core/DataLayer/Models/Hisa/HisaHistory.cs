using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Micro_core.Models.Hisa
{
    public class HisaHistory
    {
        public int ID { get; set; }
        [ForeignKey("hisa")]
        public string hisaId { get; set; }
        public int StaffId { get; set; }
        public int Hisa { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
        [JsonIgnore]
        public virtual MainHisa hisa { get; set; }
    }
}