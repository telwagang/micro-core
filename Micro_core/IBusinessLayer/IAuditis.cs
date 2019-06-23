using Micro_core.DataLayer.Models.Emuns;

namespace Micro_core.IBusinessLayer
{
    public interface IAuditis
    {
         void System(MicroAuditType  type,int id, string message = null);
    }
}