using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback.DomainModel
{
    public static class DateUtils
    {
        private static double? DaysToAddOnNow = 0;
        public static DateTime Now()
        {
            return DateTime.Now.AddDays(DaysToAddOnNow.Value);
        }
    }
}
