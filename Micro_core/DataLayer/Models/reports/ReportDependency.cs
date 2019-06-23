using System.ComponentModel.DataAnnotations.Schema;
using Micro_core.DataLayer.Models.Emuns;

namespace Micro_core.DataLayer.Models.reports
{
    [Table("tbl_report_dependency")]
    public class ReportDependency
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int Dependant { get; set; }
        public int DependencyId { get; set; }
        public MicroDependentType DependentType { get; set; }
       public bool Deleted { get; set; }
    }
}