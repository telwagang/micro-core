using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;
using Micro_core.DataLayer.Models.Emuns;

namespace API.DataModels.reports
{
    [Table("tbl_report_dependency")]
    public class ReportDependency: IBaseModel
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int Dependant { get; set; }
        public int DependencyId { get; set; }
        public MicroDependentType DependentType { get; set; }
       public bool Deleted { get; set; }
    }
}