using System.Collections.Generic;
using Micro_core.DataLayer.Models.reports;
using Micro_core.Models;

namespace Micro_core.IBusinessLayer
{
    public interface IReport
    {
         void SavaReport(Reports r); 

         Reports GetReport(int id); 

         void ReportFields(List<FieldValueView> fields,int reportId); 

         void UpdateVersion(int id); 
          
    }
}