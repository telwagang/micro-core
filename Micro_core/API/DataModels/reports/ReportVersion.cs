using System;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;
using Micro_core.IBusinessLayer;

namespace API.DataModels.reports
{
    [Table("tbl_report_version")]
    public class ReportVersion : IVersion
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public int ReportId { get; set; }
        public DateTime Date { get; set; }
        public bool Deleted { get; set; }
    }
}