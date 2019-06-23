using System.Collections.Generic;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.Models;

namespace Micro_core.DataLayer.Models
{
    public class ReportVIewModel
    {
        public int reportId {get;set ; }

        public MicroColumn DisplayStyle { get;set ; }

        public List<ReportFields> Fields {get; set; }
    }

    public class ReportFields{

        public int EntityPageId {get; set; }
        public int ReportPageId {get; set; }

        public FieldValueView Field {get;set;}
    }
}