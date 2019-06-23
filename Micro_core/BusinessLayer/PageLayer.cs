using System.Collections.Generic;
using System.Linq;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.reports;
using Micro_core.IBusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace Micro_core.BusinessLayer
{
    public class PageLayer : IPage
    {
        private readonly IAuditis _audite;
        private readonly IFields _fieldsLayer; 
       
        public PageLayer(IAuditis audite, IFields fields)
        {
            _audite = audite;
            _fieldsLayer = fields; 
        }

        public Pages GetPage(int id)
        {
            using(var ctx = new MicroContext())
            {
                return ctx.Page
                //.Include(x=> x.EntityType)
                .FirstOrDefault(x=> x.Id == id); 
            }
        }

        public List<Pages> GetPages(bool include = false)
        {
            using (var ctx = new MicroContext())
            {
                var list =  ctx.Page.Where(x=> !x.Delete);

                if(include){
                var newlist = new List<Pages>(); 

                foreach (var item in list)
                {
                    var e =  ctx.EntityPage.Where(v=> v.PageId == item.Id)
                .Select(c=> c.EntityId);

                  var f = new Pages(); 
                  f.Id = item.Id;
                  f.Name = item.Name;
                  f.Delete = item.Delete;
                  f.ArithmeticType = item.ArithmeticType;
                  f.Active = item.Active;
                  f.Type = item.Type;
                  
                  f.EntityTypes = ctx.EntityType.Where(x=> e.Contains(x.Id) && !x.Delete).ToList();
                
                 newlist.Add(f); 
                }
                 return newlist; 

                //list.Include(x=> x.EntityPages).ThenInclude(x=> x.EntityTypes);
                } 
            return list.ToList(); 
            }
        }

        public void SetPage(Pages page)
        {
            try
            {
                if (string.IsNullOrEmpty(page.Name))
                    throw new MicroException("Page name is missing");

                if (page.ArithmeticType == default(MicroArithmetic))
                    throw new MicroException("Arthmetic Type not selected");

                SaveOrUpdate(page, page.Id);

                var pe = GetPageEntityByPageId(page.Id); 

                foreach (var entity in page.EntityTypes)
                {
                    var e = pe.Find((obj) => obj.EntityId == entity.Id); 

                    if(e != null) continue;

                    e  =   new EntityPages
                              {
                                  EntityId = entity.Id,
                                  PageId = page.Id
                              };

                    SaveOrUpdate(e, e.Id); 

                }

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private List<EntityPages> GetPageEntityByPageId(int pageId)
        {
            using(var ctx = new MicroContext())
            {
                return ctx.EntityPage.Where(x => x.PageId == pageId).ToList();
            }
        }


        private void SaveOrUpdate<T>(T objectT, int id) where T : class
        {
            using (var ctx = new MicroContext())
            {
                if (id == 0)
                {
                    ctx.Set<T>().Add(objectT);
                }
                else
                {
                    ctx.Entry<T>(objectT).State = EntityState.Modified;
                }
                ctx.SaveChanges();

            }
        }
    }
}