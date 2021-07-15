using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp
{
    public class DayOfWeekProvider
    {
        public string GetDayOfWeek() 
        {
            var now = DateTime.Now;
            var day = now.DayOfWeek;
            return day.ToString();
        }
    }
}
