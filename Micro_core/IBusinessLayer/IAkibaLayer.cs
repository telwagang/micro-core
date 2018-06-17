using System.Collections.Generic;
using Micro_core.DataLayer.Models;

namespace Micro_core.IBusinessLayer
{
    public interface IAkibaLayer
    {
         void StartSavingAccount(akibaViewModel avm); 
         void UpdateSavingAccount(akibaViewModel avm);
         List<AkibaMultipleViewModel> GetAkibaHistory(int companyId);
    }
}