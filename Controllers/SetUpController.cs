using System.Collections.Generic;
using Micro_core.Models;
using Micro_core.Models.Loan;
using Microsoft.AspNetCore.Mvc;

namespace Micro_core.Controllers
{
    [Route("api/[controller]")]
    public class SetUpController: Controller
    {
        [HttpPost("[action]")]
        public IActionResult SetCompany([FromBody] Company company)
        {
            if(company == null){
                return BadRequest();
            } 
            company.save();

            return Ok(company);
        }

        [HttpGet("[action]")]
        [Produces("application/json")]
        public IActionResult GetCompany() {
            return Ok(Company.GetCompany());
         }
        
        [HttpGet("[action]")]
        [Produces("application/json")]
         public IActionResult GetStaff() { 
             return Ok(Staff.All());
         }

        [HttpGet("[action]/{id}")]
        [Produces("application/json")]
         public IActionResult GetStaff(int id){
             
             return Ok(Staff.GetById(id));
         }

          [HttpPost("[action]")]
        public IActionResult SetStaff([FromBody] Staff staff)
        {
            if(staff == null){
                return BadRequest();
            } 
            staff.save();

            return Ok(staff);
        }
        [HttpGet("[action]")]
        [Produces("application/json")]
         public IActionResult GetInterest() { 
             return Ok(Interest.All());
         }

        [HttpGet("[action]/{id}")]
        [Produces("application/json")]
         public IActionResult GetInterest(int id){
             
             return Ok(Interest.GetById(id));
         }

          [HttpPost("[action]")]
        public IActionResult SetInterest([FromBody] Interest inter)
        {
            if(inter == null){
                return BadRequest();
            } 
            inter.save();

            return Ok(inter);
        }
    }
}