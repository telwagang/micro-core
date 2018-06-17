using Micro_core.BusinessLayer;
using Micro_core.DataLayer.Attributes;
using Microsoft.AspNetCore.Mvc;
using Micro_core.IBusinessLayer;
using Micro_core.Models;
using System;
using Micro_core.DataLayer.Models;

namespace Micro_core.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoanController : Controller
    {

        private readonly ILoanLayer _loanLayer;


        public LoanController(ILoanLayer loanlayer)
        {
            _loanLayer = loanlayer;
        }

        [HttpGet("action/id")]
        [Produces("application/json")]
        public IActionResult GetPending(int id)
        {

            try
            {
                var d = _loanLayer.GetPending(id);

                return Ok(d);
            }
            catch (MicroException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception)
            {
                return NotFound("something went wrong");
            }
        }
        [HttpPost("action")]
        public IActionResult SetLoan([FromBody] LoanApplication la)
        {
            try
            {
                _loanLayer.NewLoanApplication(la);

                return Ok();
            }
            catch (MicroException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return NotFound("Something went wrong");
            }
        }

        [HttpPost("action")]
        public IActionResult PayLoan([FromBody] paymentViewModel pvm){
            try
            {
                _loanLayer.PayLoan(pvm); 
                return Ok();
            }
            catch(MicroException ex){
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return NotFound("something went wrong");
            }
        }
    }
}