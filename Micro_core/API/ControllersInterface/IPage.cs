using API.DataModels.reports;
using System.Collections.Generic;


namespace API.ControllersInterface
{
    public interface IPage
    {
         Pages GetPage(int id); 
         List<Pages> GetPages(bool include);
         void SetPage(Pages page); 
    }
}