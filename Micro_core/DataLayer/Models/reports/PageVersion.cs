using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Micro_core.IBusinessLayer;

namespace Micro_core.DataLayer.Models.reports
{
    [Table("tbl_page_version")]
    public class PageVersion: IVersion
    {
        [Key]
        public int Id { get; set; }
        public int Version { get; set; }
        public int PageId { get; set; }
        
        public DateTime Date { get; set; }
        
    }
}