using System.Collections.Generic;
using Micro_core.DataLayer.Models.reports;

namespace Micro_core.IBusinessLayer
{
    public interface IPage
    {
         Pages GetPage(int id); 
         List<Pages> GetPages(bool include);
         void SetPage(Pages page); 
    }
}