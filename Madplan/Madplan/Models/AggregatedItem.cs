namespace Madplan.Models
{
    public class AggregatedItem
    {
        public Guid Id { get; set; }
        public Guid ShoppingListId { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public bool IsManual { get; set; } = false;
    }
}
