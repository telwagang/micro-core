using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;

namespace API.DataModels.reports
{
    [Table("tbl_reports")]
    public class Reports: IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [DefaultValue(false)]
        public bool Active { get; set; }
        [DefaultValue(false)]
        public bool Delete { get; set; }

        public ICollection<Pages> Pages { get; } = new List<Pages>(); 
        public ICollection<ReportVersion> ReportVersion {get;} = new List<ReportVersion>(); 
        public ICollection<ReportDependency> ReportDependency { get; } = new List<ReportDependency>();
      }
}