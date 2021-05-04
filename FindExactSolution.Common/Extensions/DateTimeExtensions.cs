using System;

namespace FindExactSolution.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ConvertToDefaultDateFormat(this DateTime date)
        {
            return date.ToString("dd MMMM yyyy H:mm");
        }

        public static int GetDaysLeft(this DateTime date)
        {
            var nextSelectedDate = date.AddYears(DateTime.Today.Year - date.Year);

            if (nextSelectedDate < DateTime.Today) return 0;

            return (nextSelectedDate - DateTime.Today).Days;
        }
    }
}