using Micro_core.DataLayer.Models.Emuns;
using Micro_core.IBusinessLayer;

namespace Micro_core.BusinessLayer
{
    public class Audits : IAuditis
    {
        public void System(MicroAuditType type, int id, string message = null)
        {
            //throw new System.NotImplementedException();
        }
    }
}