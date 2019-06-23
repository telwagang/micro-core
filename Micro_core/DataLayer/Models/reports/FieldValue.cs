using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Micro_core.DataLayer.Models.Emuns;

namespace Micro_core.DataLayer.Models.reports
{
    [Table("tbl_Field_Value")]
    public class FieldValue
    {
        [Key]
        public int Id { get; set; }
        public int VerisonId { get; set; }
        public int PageId {get; set;}
        public int FieldId { get; set; }
        public MicroValueType Type { get; set; }

        public string StringValue { get; set; }
        public int? Selectvalue { get; set; }
        public decimal? DecimalValue { get; set; }
        public DateTime? DateValue { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}