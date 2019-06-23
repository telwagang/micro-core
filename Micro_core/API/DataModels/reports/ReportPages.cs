using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;
using Micro_core.DataLayer.Models.Emuns;

namespace API.DataModels.reports
{
    [Table("tbl_report_pages")]
    public class ReportPages : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int ReportId { get; set; }
        public int PageId { get; set; }
        public MicroColumn Column { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set;}
    }
}