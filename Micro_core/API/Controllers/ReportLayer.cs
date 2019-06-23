using System;
using System.Collections.Generic;
using System.Linq;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Extension;
using Micro_core.DataLayer.Models.Base;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.reports;
using Micro_core.IBusinessLayer;
using Micro_core.Models;


namespace Micro_core.BusinessLayer
{
    public class ReportLayer: IReport //BaseLayer,  IReport 
    {
        private readonly BaseLayer _baseLayer ; 
        private readonly MicroContext  _mctx ; 
        private readonly IFields _fields; 
        public ReportLayer(MicroContext ctx, IFields fields, BaseLayer baseLayer){
        //BaseLayer(_mctx); 
        _baseLayer = baseLayer;
        _mctx = ctx; 
        _fields = fields;
        }

        public Reports GetReport(int id)
        {
            using (var ctx = _mctx)
            {
               return ctx.Report.FirstOrDefault(x=> x.Id == id); 
            }
        }

        public void ReportFields(List<FieldValueView> fields, int reportId)
        {
           var rv = GetReportVersion(reportId); 
           
            _fields.SaveFields(fields, MicroValueType.Report, reportId); 

        }

        private ReportVersion GetReportVersion(int reportId)
        {
            using (var ctx = _mctx)
            {
                return ctx.ReportVersion
                .Where(x=> x.ReportId == reportId).
                OrderByDescending(x=> x.Version).FirstOrDefault(); 
            }
        }

        public void SavaReport(Reports r)
        {
            if(string.IsNullOrEmpty(r.Name))
              throw new MicroException("Report name cannot be empty"); 
            
            if(IsNameUsed(r.Name)) 
              throw new MicroException("Report name has been used already"); 
             
             _baseLayer.SaveOrUpdate(r, r.Id); 

        }

        private bool IsNameUsed(string name)
        {
            using (var ctx = _mctx)
            {
                return ctx.Report.Any(x=> x.Name.Contains(name)); 
            }
        }

        public void UpdateVersion(int id)
        {
            var l = GetReportVersion(id);
            if (DateTime.UtcNow.Date != DateTime.UtcNow.LastDayOfMonth().Date)
                throw new MicroException("Version can only be added if its the end of the month");

            if (l.Date.Month == DateTime.UtcNow.Month)
                throw new MicroException("Only one version can be add per month");

            ++l.Version;
            l.Id = 0;

            _baseLayer.SaveOrUpdate(l, 0);
        }
    }
}