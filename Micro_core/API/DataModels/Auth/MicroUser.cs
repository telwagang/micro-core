using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.DataModels.Management;
using API.Enums;
using API.Interface;
using Micro_core.Models;

namespace API.DataModels.Auth
{
    public class MicroUser : IBaseModel
    {

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password
        {
            get; set;
            // get { return Password; }
            // set
            // {
            //     if (!string.IsNullOrEmpty(value))
            //     {
            //         Password = value;
            //         //Password = BCrypt.Net.BCrypt.HashPassword(value, BCrypt.Net.BCrypt.GenerateSalt());
            //     }
            // }
        }
        [NotMapped]
        public string EncyptPassword { get; set; }
        public string AccessToken { get; set; }
        public MicroUserType Type { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LockOutUntill { get; set; }
        public bool LockOut { get; set; }
        public bool Deleted { get; set; }

        public ICollection<Roles> Roles { get; } = new List<Roles>();

        public LoginViewModel ReturnToClient()
        {
            var staff = Staff.GetByApiKey(Id.ToString());
            return new LoginViewModel
            {
                Username = Username,
                id = Id,
                ApiKey = AccessToken,
                Type = Type,
                TypeId =  staff?.id ?? 0,
                CompanyId =  staff?.CompanyId ?? 0
            };
        }

    }
}