using API.DataModels.reports;
using System.Collections.Generic;


namespace API.ControllersInterface
{
    public interface IReport
    {
         void SavaReport(Reports r); 

         Reports GetReport(int id); 

         void ReportFields(List<FieldValueView> fields,int reportId); 

         void UpdateVersion(int id); 
          
    }
}