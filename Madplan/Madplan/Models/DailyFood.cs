namespace Madplan.Models
{
    public class DailyFood
    {
        public Guid Id { get; set; }
        public Guid FoodPlanId { get; set; }
        public string Day { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int NumberOfServings { get; set; } = 2;
    }
}
