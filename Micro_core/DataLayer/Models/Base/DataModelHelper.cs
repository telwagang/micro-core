using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Micro_core.DataLayer.Models.Base
{
    public class DataModelHelper
    {
        
    }

    public static class ClassExtensions{

        public static DateTime LastDayOfMonth(this DateTime date){
            return date.AddMonths(1).AddDays(-1); 
        }
    }
}