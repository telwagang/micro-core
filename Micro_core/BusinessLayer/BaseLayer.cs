using Micro_core.DataLayer;
using Micro_core.IBusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace Micro_core.BusinessLayer
{
    public class BaseLayer:IBaseLayer
    {

        private readonly MicroContext _ctx; 
        public BaseLayer(MicroContext ctx){
        _ctx = ctx; 
        }
        public void SaveOrUpdate<T>(T objectT, int id) where T : class
        {
            using (var ctx = _ctx)
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