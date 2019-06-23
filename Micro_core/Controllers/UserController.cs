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
         public MicroResponse GetCustomers(string id){
             
             return new MicroResponse(Customer.GetById(id));
         }

        [HttpPost("[action]")]
        public MicroResponse SetCustomer([FromBody] Customer customer)
        {
            if(customer == null){
                return new MicroResponse("customer not found");
            } 
            customer.save();

            return new MicroResponse(customer);
        }

        [HttpGet("[action]/{name}")]
        [Produces("application/json")]
         public MicroResponse SearchCustomer(string name){
             
             return new MicroResponse(Customer.GetByName(name));
         }
        

    }
}
