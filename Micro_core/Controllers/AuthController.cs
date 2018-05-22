using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public IActionResult Login([FromBody] LoginViewModel user)
        {

            try
            {
                var _user = new IApplicationUser().signInWithEmailAndPassword(user);
                if (_user == null) return NotFound();

                return Ok(_user.Type);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }

        }
        [HttpPost("[action]")]
        public IActionResult SignUp([FromBody] LoginViewModel user)
        {

            try
            {
                var accestoken = new IApplicationUser().singUpWithEmailAndPassword(user);
                
                return Ok(accestoken);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpGet("[action]/{key}")]
        public IActionResult VerifyKey(string key)
        {
            if(string.IsNullOrEmpty(key)){
                return BadRequest();
            }

            if(Staff.GetByApiKey(key) == null){
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("[action]/{token}")]
        public IActionResult VerifyToken(string token) {

         if(string.IsNullOrEmpty(token)) return Ok(false); 
          
          return Ok(MicroUser.CheckByToken(token)); 

         }
    }
}
