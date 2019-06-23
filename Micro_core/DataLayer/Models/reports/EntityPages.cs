using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Micro_core.DataLayer.Models.reports
{
    [Table("tbl_Entity_page")]
    public class EntityPages
    {
        
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int PageId { get; set; }

        public EntityType EntityTypes { get; set;}  
        public Pages Pages {get; set;}
    }
}