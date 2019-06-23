using System;
using System.Linq;
using System.Threading.Tasks;
using API.DataModels.akiba;
using API.Enums;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class AkibaRepository : IAkibaRepository
    {
        public readonly IBaseRepository _baseRepository; 

        public AkibaRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository; 
        }

        public async Task<AkibaAccount> GetByCustomer(string id)
        {
            return await _baseRepository._microContext.AkibaAccounts.
                                        FirstOrDefaultAsync(x => x.CustomerId == id 
                                                            && x.TranscationType == MicroAkibaType.Start && !x.Deleted);
        }

        public async Task<AkibaAccount> GetLastbalance(string id)
        {
            return await _baseRepository._microContext.AkibaAccounts.Where(x => x.CustomerId == id && !x.Deleted)
                .OrderByDescending(x => x.Date).FirstOrDefaultAsync();
        }

        public async Task<AkibaAccount> GetLastbalance(string id, MicroAkibaType type)
        {
            return await _baseRepository._microContext.AkibaAccounts.Where(x => x.CustomerId == id && x.TranscationType == type && !x.Deleted)
                .OrderByDescending(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
