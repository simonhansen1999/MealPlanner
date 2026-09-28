using System.Globalization;

namespace Madplan.Services
{
    public class GlobalVariables
    {
        public static readonly string[] DaysOfWeek = new[]
           {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            }
           .Select(d =>
           {
               var name = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat.GetDayName(d);
               return string.IsNullOrEmpty(name) ? name : char.ToUpper(name[0], CultureInfo.GetCultureInfo("da-DK")) + name.Substring(1);
           })
           .ToArray();

        public static readonly int[] ServingsMap = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

        public static readonly string[] SearchTerms = { "Navn (A-Z)", "Navn (Z-A)", "Favoritter" };

        public static readonly int GoogleAuthenticationDays = 3;
    }
}
