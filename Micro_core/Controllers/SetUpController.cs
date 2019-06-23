using System.Collections.Generic;
using API.DataModels.Management;
using Micro_core.DataLayer.Models;
using Micro_core.DataLayer.Models.Management;
using Micro_core.IBusinessLayer;
using Micro_core.Models;
using Micro_core.Models.Loan;
using Microsoft.AspNetCore.Mvc;

namespace Micro_core.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SetUpController : Controller
    {
        private readonly ISetupLayer _setupLayer; 
        public SetUpController(ISetupLayer setupLayer)
        {
            _setupLayer = setupLayer; 
        }

        [HttpPost("[action]")]
        public MicroResponse SetCompany([FromBody] Company company)
        {
            if (company == null)
            {
                return new MicroResponse(ModelState.ValidationState);
            }
            _setupLayer.SetCompany(company); 

            return new MicroResponse(company);
        }

        [HttpGet("[action]")]
        [Produces("application/json")]
        public MicroResponse GetCompany()
        {
            return new MicroResponse(_setupLayer.GetCompany());
        }

        [HttpGet("[action]")]
        [Produces("application/json")]
        public MicroResponse GetStaff()
        {
            return new MicroResponse(_setupLayer.GetStaff());
        }

        [HttpGet("[action]/{id}")]
        [Produces("application/json")]
        public MicroResponse GetStaff(int id)
        {

            return new MicroResponse(_setupLayer.GetStaff(id));
        }

        [HttpPost("[action]")]
        public MicroResponse SetStaff([FromBody] Staff staff)
        {
            if (staff == null)
            {
                return new MicroResponse();
            }

            _setupLayer.SetStaff(staff); 

            return new MicroResponse(staff);
        }

        [HttpGet("[action]")]
        [Produces("application/json")]
        public MicroResponse GetInterest()
        {
            return new MicroResponse(_setupLayer.GetInterest());
        }

        [HttpGet("[action]/{id}")]
        [Produces("application/json")]
        public MicroResponse GetInterest(int id)
        {

            return new MicroResponse(_setupLayer.GetInterest(id));
        }

        [HttpPost("[action]")]
        public MicroResponse SetInterest([FromBody] interestViewModel inter)
        {
            if (inter == null)
            {
                return new MicroResponse();
            }
            _setupLayer.SetInterest(inter); 

            return new MicroResponse(inter);
        }

    }
}