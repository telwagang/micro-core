using System.ComponentModel.DataAnnotations.Schema;
using API.Interfaces;

namespace API.DataModels.Management
{
    [Table("tbl_user_role")]
    public class UserRoles : IBaseModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
    }
}