namespace Madplan.Models
{
    public class AppUserSettings
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public int DefaultNumberOfServings { get; set; } = 2;
    }
}
