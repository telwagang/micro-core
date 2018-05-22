using System;
using System.Linq;
using System.Net;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Models.Auth;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.Management;
using Micro_core.Models;

namespace Micro_core.BusinessLayer
{
    public class IApplicationUser
    {
        
        private MicroUser _user = null;
        public IApplicationUser()
        {
            
        }


        /// <summary>
        /// Warp in try catch 
        ///</summary>
        public MicroUser signInWithEmailAndPassword(LoginViewModel user)
        {

            _user = MicroUser.GetByUsername(user.Username);


            if (_user == null || !BCrypt.Net.BCrypt.Verify(user.Password, _user.Password))
            {
                throw new MicroException(HttpStatusCode.NoContent, "In Correct Username and Password");
            }
            else if (_user.Deleted)
            {
                throw new MicroException(HttpStatusCode.Unauthorized, "User has been deleted");

            }
            else if (_user.LockOut)
            {
                throw new MicroException(HttpStatusCode.Forbidden, $"User locked out untill: {_user.LockOutUntill:u}");
            }

            UpdateLastLogin();

            _user.save();

            return _user;


        }

        /// <summary>
        /// Warp in try catch 
        ///</summary>
        ///<value>returns Access token</value>
        public string singUpWithEmailAndPassword(LoginViewModel user)
        {
            
                var staff = Staff.GetByApiKey(user.ApiKey);

                if (staff == null)
                {
                    throw new MicroException(HttpStatusCode.BadRequest, "Invailed key");
                }

                _user = MicroUser.GetByUsername(user.Username) ?? 
                new MicroUser
                {
                    Username = user.Username,
                    Password = user.Password,
                    Type = MicroUserType.Staff, 
                    AccessToken = Guid.NewGuid().ToString("N").Substring(5, 6).ToUpper()
                    
                };

                if(_user.Id > 0) {
                    throw new MicroException(HttpStatusCode.NotAcceptable, "User already exsits ");
                }

                _user.FirstDay = DateTime.UtcNow;

                UpdateLastLogin();

                _user.save();
                
                staff.UserID = _user.Id.ToString();

                staff.save();

                return _user.AccessToken;
        }
        private void UpdateLastLogin()
        {
            _user.LastLogin = DateTime.UtcNow;
            _user.LockOut = false;

        }


    }
}