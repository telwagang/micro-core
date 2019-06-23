using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataModels;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public MicroContext _microContext { get; set; }
        public BaseRepository(MicroContext context)
        {
            _microContext = context; 
        }

       
        public async Task AddOrUpdate<T>(T item) where T : class,IBaseModel, new()
        {
            if (item.Id == 0)
            {
                await _microContext.Set<T>().AddAsync(item);
            }
            else
            {
                _microContext.Entry(item).State = EntityState.Modified;
            }
             await _microContext.SaveChangesAsync();
        }

        public async Task Delete<T>(T item) where T : class, IBaseModel, new()
        {
            _microContext.Entry(item).State = EntityState.Deleted;
            await _microContext.SaveChangesAsync();
        }

        public async Task<T> GetById<T>(int id) where T : class, IBaseModel, new()
        {
            return await _microContext.Set<T>().FindAsync(id); 
        }

        public async Task<List<T>> GetCollection<T>() where T : class, IBaseModel
        {
            return await _microContext.Set<T>().ToListAsync(); 
        }

        public async Task Update<T>(T item) where T : class, IBaseModel, new()
        {
            
        }
    }
}
