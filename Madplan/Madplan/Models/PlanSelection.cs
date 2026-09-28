namespace Madplan.Models
{
    public class PlanSelection
    {
        public Guid PlanId { get; set; }
        public bool IncludeWeek { get; set; } = false;
        public HashSet<string> SelectedDays { get; set; } = new();
        public PlanSelection() { }
        public PlanSelection(Guid id)
        {
            PlanId = id;
        }
    }
}
