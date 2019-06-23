using API.Interfaces;

namespace API.DataModels.Management
{
    public class RoleRights : IBaseModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int Right { get; set; }
    }
}