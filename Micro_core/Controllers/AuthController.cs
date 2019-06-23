using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Micro_core.BusinessLayer;
using Micro_core.DataLayer.Models.Auth;
using Micro_core.DataLayer.Models.Management;
using Micro_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Micro_core.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : Controller
    {
        [HttpPost("[action]")]
        public MicroResponse Login([FromBody] LoginViewModel user)
        {

            try
            {
                var _user = new IApplicationUser().signInWithEmailAndPassword(user);
                if (_user == null) return new MicroResponse("User not found");
                
               
                return new MicroResponse(_user.ReturnToClient());
            }
            catch (Exception e)
            {

                return new MicroResponse(e.Message);
            }

        }
        [HttpPost("[action]")]
        public MicroResponse SignUp([FromBody] LoginViewModel user)
        {

            try
            {
                var accestnew = new IApplicationUser().singUpWithEmailAndPassword(user);
                
                return new MicroResponse(accestnew,HttpStatusCode.OK);
            }
            catch (Exception e)
            {

                return new MicroResponse(e.Message);
            }

        }
        [HttpGet("[action]/{key}")]
        public MicroResponse VerifyKey(string key)
        {
            if(string.IsNullOrEmpty(key)){
                return new MicroResponse("key not found");
            }

            if(Staff.GetByApiKey(key) == null){
                return new MicroResponse("key not found"); 
            }

            return new MicroResponse();
        }

        [HttpGet("[action]/{token}")]
        public MicroResponse VerifyToken(string token) {

         if(string.IsNullOrEmpty(token)) return new MicroResponse(false); 
          
          return new MicroResponse(MicroUser.CheckByToken(token)); 

         }
    }
}
