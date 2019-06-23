using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Models.reports;
using Micro_core.IBusinessLayer;
using Micro_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Micro_core.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EntityTypeController: Controller
    {
        private readonly IFields _fieldLayer; 
        private readonly IPage _pageLayer; 

        public EntityTypeController(IFields fields, IPage page) {
            _fieldLayer = fields;
            _pageLayer = page; 
        }

        [HttpPost("[action]")]
        public MicroResponse SetEntity([FromBody] EntityType  entity){
            try
            {
                if(string.IsNullOrEmpty(entity.Name))
                 throw new MicroException("Model not valid"); 

                _fieldLayer.SetFields(entity); 
                return new MicroResponse();
            }
            catch(MicroException c){
                return new MicroResponse(c.Message);
            }
            catch (System.Exception)
            {
                return new MicroResponse("something went wrong");
            }
        }
        [HttpGet("[action]/{id}")]
        //[Produces("application/json")]
        public MicroResponse GetEntity(int id)
        {
            try
            {
               var e = _fieldLayer.GetEntityById(id); 
               if(e == null)
                  throw new MicroException("The entity type couldnt be found."); 
                  
                return new MicroResponse(e); 

            }
             catch(MicroException c){
                return new MicroResponse(c.Message);
            }
            catch (System.Exception)
            {
                return new MicroResponse("something went wrong");
            }

        }

        [HttpGet("[action]")]
        public MicroResponse GetEntities(){
            return new MicroResponse(_fieldLayer.GetEntities()); 
        }

        [HttpGet("[action]/{id}")]
        public MicroResponse GetField(int id) 
        { 
            try
            {
                return new MicroResponse(_fieldLayer.Get(id)); 
            }
            catch (System.Exception)
            {
                
                return new MicroResponse("something went wrong"); 
            }
         }

        [HttpGet("[action]/{id}")]
         public MicroResponse GetFields(int id) 
         { 
             return new MicroResponse(_fieldLayer.GetEntityWithFields(id)); 
         }

     [HttpGet("[action]/{id}")]
     public MicroResponse GetPage(int id)
     {
            return new MicroResponse(_pageLayer.GetPage(id));
     }
     [HttpGet("[action]")]
     public MicroResponse GetPages()
     {
            return new MicroResponse(_pageLayer.GetPages(true));
     }

    [HttpPost("[action]")]
      public MicroResponse SetPage([FromBody] Pages page)
     {
            try
            {
                _pageLayer.SetPage(page);

                return new MicroResponse();

            }
            catch (MicroException c)
            {
                return new MicroResponse(c.Message);
            }
            catch (System.Exception)
            {
                return new MicroResponse("something went wrong");
            }
        }

    }
}