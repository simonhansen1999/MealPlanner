using System.Globalization;

namespace Madplan.Models
{
    public class FoodPlan
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public int WeekNumber { get; set; } = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        public int Year { get; set; } = DateTime.Now.Year;
        public List<DailyFood> Foods { get; set; } = [];
        public List<FoodPlanShare> SharedWith { get; set; } = [];
        public List<FoodPlanFamilyGroupShare> SharedWithFamilyGroups { get; set; } = [];
    }
}
