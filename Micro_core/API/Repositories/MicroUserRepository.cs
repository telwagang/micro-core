using System;
using System.Threading.Tasks;
using API.DataModels.Auth;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
	public class MicroUserRepository : IMicroUserRepository
    {
        public readonly IBaseRepository _baseRepository;

        public MicroUserRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository; 
        }

        public async Task<object> CheckByToken(string token)
        {
            return await _baseRepository
                ._microContext.User.AnyAsync(x => x.AccessToken == token);
        }

        public async Task<MicroUser> GetById(int id)
        {
            return await _baseRepository.GetById<MicroUser>(id); 
        }

        public async Task<MicroUser> GetByUsername(string username)
        {
            return await _baseRepository
                ._microContext.User
                .FirstOrDefaultAsync(x => x.Username == username &&
                 !x.Deleted);
        }

        public async Task Save(MicroUser user)
        {
            await _baseRepository.AddOrUpdate(user); 
        }
    }
}
