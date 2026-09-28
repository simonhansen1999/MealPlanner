namespace Madplan.Models
{
    public class FavoriteFood
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid Food { get; set; }
    }
}
