using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;
using Micro_core.DataLayer.Models.Auth;

namespace API.DataModels.Management
{
    [Table("tbl_roles")]

    public class Roles : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public ICollection<MicroUser> User { get; } = new List<MicroUser>(); 
        public ICollection<RoleRights> RoleRights { get; } = new List<RoleRights>();
     }
}