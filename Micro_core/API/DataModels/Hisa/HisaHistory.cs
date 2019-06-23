using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;
using Newtonsoft.Json;

namespace API.DataModels.Hisa
{
    public class HisaHistory : IBaseModel
    {
        public int Id { get; set; }
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