using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;
using Micro_core.DataLayer.Models.Emuns;

namespace API.DataModels.reports
{
    [Table("tbl_pages")]
    public class Pages : IBaseModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public MicroArithmetic ArithmeticType { get; set; }
        
        public MicroPageType Type { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }
        [DefaultValue(false)]
        public bool Delete { get; set; }

        public ICollection<Reports> Reports { get; } = new List<Reports>(); 
        public ICollection<EntityPages> EntityPages   { get; } = new List<EntityPages>(); 
        public ICollection<PageVersion> PageVersions {get; } = new List<PageVersion>();
        [NotMapped]
        public IList<EntityType> EntityTypes {get; set;}
   } 
}