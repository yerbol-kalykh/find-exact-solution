using System;

namespace FindExactSolution.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ConvertToDefaultDateFormat(this DateTime date)
        {
            return date.ToString("dd MMMM yyyy H:mm");
        }
    }
}