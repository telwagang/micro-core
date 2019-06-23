using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;

namespace API.DataModels.reports
{
    [Table("tbl_Entity_page")]
    public class EntityPages: IBaseModel
    {
        
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int PageId { get; set; }

        public EntityType EntityTypes { get; set;}  
        public Pages Pages {get; set;}
    }
}