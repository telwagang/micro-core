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

        [HttpGet("[action]/{id}")]
        [Produces("application/json")]
        public MicroResponse GetPending(int id)
        {

            try
            {
                var d = _loanLayer.GetPending(id);

                return new MicroResponse(d);
            }
            catch (MicroException ex)
            {
                return new MicroResponse(ex.Message);
            }
            catch (System.Exception)
            {
                return new MicroResponse("something went wrong");
            }
        }
        [HttpPost("[action]")]
        public MicroResponse SetLoan([FromBody] LoanApplication la)
        {
            try
            {
                _loanLayer.NewLoanApplication(la);

                return new MicroResponse();
            }
            catch (MicroException ex)
            {

                return new MicroResponse(ex.Message);
            }
            catch (Exception)
            {

                return new MicroResponse("Something went wrong");
            }
        }

        [HttpPost("[action]")]
        public MicroResponse PayLoan([FromBody] paymentViewModel pvm){
            try
            {
                _loanLayer.PayLoan(pvm); 
                return new MicroResponse();
            }
            catch(MicroException ex){
                return new MicroResponse(ex.Message);
            }
            catch (Exception)
            {
                return new MicroResponse("something went wrong");
            }
        }
    }
}