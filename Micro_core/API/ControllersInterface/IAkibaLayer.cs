using System.Collections.Generic;


namespace API.ControllersInterface
{
    public interface IAkibaLayer
    {
         void StartSavingAccount(akibaViewModel avm); 
         void UpdateSavingAccount(akibaViewModel avm);
         List<AkibaMultipleViewModel> GetAkibaHistory(int companyId);
    }
}