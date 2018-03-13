using System;
using System.Linq.Expressions;
using Micro_core.DataLayer;

namespace Micro_core.Models
{
    public class InterfaceModel
    {

        public void Update<T>(T obj, params Expression<Func<T, object>>[] properies) where T : class
        {
            using (var db = new MicroContext())
            {
                db.Set<T>().Attach(obj);

                foreach (var p in properies)
                {
                    db.Entry(obj).Property(p).IsModified = true;
                }
            }






        }
    }
}