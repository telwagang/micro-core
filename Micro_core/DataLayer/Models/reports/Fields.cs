using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.reports;

namespace Micro_core.DataLayer.Models.reports
{
    [Table("tbl_Fields")]
    public class Fields
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Entity")]
        public int EntityId { get; set; }
        public MicroDataType DataType { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public bool Required { get; set; }
        public bool System {get; set; }
        public int Order { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }


        public virtual EntityType Enity { get; set; }
    }
}