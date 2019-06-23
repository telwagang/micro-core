using Micro_core.DataLayer.Models.Emuns;

namespace API.ControllersInterface
{
    public interface IAuditis
    {
         void System(MicroAuditType  type,int id, string message = null);
    }
}