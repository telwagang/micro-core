using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Micro_core.BusinessLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Models;
using Micro_core.IBusinessLayer;
using Micro_core.Models;
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
        public MicroResponse GetAkibaHistory(int companyId)
        {
            try
            {
                var ahViewModels = _akibaLayer.GetAkibaHistory(companyId);

                return new MicroResponse(ahViewModels);
            }
            catch (MicroException ex)
            {
                return ex.Response();
            }
            catch (Exception)
            {
                return new MicroResponse("Something went wrong");
            }
        }

        [HttpPost("[action]")]
        public MicroResponse SetAkiba([FromBody] akibaViewModel awk)
        {
            try
            {
                _akibaLayer.UpdateSavingAccount(awk);
                return new MicroResponse();
            }
            catch (System.Exception ex)
            {
                return new MicroResponse(ex.Message);
            }
        }
    }
}
