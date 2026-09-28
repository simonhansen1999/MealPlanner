namespace Madplan.Models
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<AggregatedItem> AggregatedItems { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
