using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Micro_core.BusinessLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Models;
using Micro_core.IBusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Micro_core.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AkibaController : Controller
    {
        private readonly IAkibaLayer _akibaLayer; 
        public AkibaController(IAkibaLayer al){
            _akibaLayer = al; 

        }
        [HttpGet("[action]/{companyId}")]
        public IActionResult GetAkibaHistory(int companyId)
        {
            try
            {
                var ahViewModels = _akibaLayer.GetAkibaHistory(companyId);

                return Ok(ahViewModels);
            }
            catch (MicroException me)
            {
                return NotFound(me.Message);
            }
            catch (Exception)
            {
                return NotFound("Something went wrong");
            }
        }

        [HttpPost("[action]")]
        public IActionResult SetAkiba([FromBody] akibaViewModel awk)
        {
            try
            {
                _akibaLayer.UpdateSavingAccount(awk);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
