using API.DataModels;
using API.DataModels.Loan;
using System.Threading.Tasks;

namespace API.Interface
{
    public interface IBaseRepository
    {
        MicroContext _microContext { get; }

        Task<T> GetById<T>(int loanId);
        Task AddOrUpdate(IBaseModel lt);
    }
}