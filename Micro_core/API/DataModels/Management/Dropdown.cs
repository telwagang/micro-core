using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Interfaces;

namespace API.DataModels.Management
{
    public class Dropdown:IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public ICollection<DropdownValues> DropdownValues { get;} = new List<DropdownValues>(); 
    }
}