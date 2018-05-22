using System.Collections.Generic;
using Micro_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Micro_core.Controllers
{
    [Route("api/[controller]")]
     [Produces("application/json")]
    public class UserController : Controller
    {

        [HttpGet("[action]")]
        public IEnumerable<Customer> GetCustomers()
        {
            return Customer.GetCustomers();
        }

        [HttpGet("[action]/{id}")]
        [Produces("application/json")]
         public IActionResult GetCustomers(string id){
             
             return Ok(Customer.GetById(id));
         }

        [HttpPost("[action]")]
        public IActionResult SetCustomer([FromBody] Customer customer)
        {
            if(customer == null){
                return BadRequest();
            } 
            customer.save();

            return Ok(customer);
        }

        [HttpGet("[action]/{name}")]
        [Produces("application/json")]
         public IActionResult SearchCustomer(string name){
             
             return Ok(Customer.GetByName(name));
         }
        

    }
}
