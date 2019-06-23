using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Micro_core.DataLayer.Models.reports
{
    [Table("tbl_Entity_Type")]
    public class EntityType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }
        [DefaultValue(false)]
        public bool Delete { get; set; }

        public ICollection<EntityPages> Entitypages { get; } = new List<EntityPages>();
        public ICollection<Fields> Fields { get; } = new List<Fields>(); 
    }
}