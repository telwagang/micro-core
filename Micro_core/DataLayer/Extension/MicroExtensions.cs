using System;

namespace Micro_core.DataLayer.Extension
{
    public static class MicroExtensions
    {

        public static DateTime LastDayOfMonth(this DateTime date){
            return date.AddMonths(1).AddDays(-1); 
        }
        
    }
}