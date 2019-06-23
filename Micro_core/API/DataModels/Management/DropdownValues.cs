using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using API.Interfaces;

namespace API.DataModels.Management
{
    public class DropdownValues:IBaseModel
    {
        [Key]
        public int  Id { get; set; }
        public int DropDownId { get; set; }
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool Default { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}