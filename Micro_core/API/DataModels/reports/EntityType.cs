using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;

namespace API.DataModels.reports
{
    [Table("tbl_Entity_Type")]
    public class EntityType: IBaseModel
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