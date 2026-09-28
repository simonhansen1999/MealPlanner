using Madplan.Models.Enums;

namespace Madplan.Models
{
    public class FoodPlanShare
    {
        public Guid Id { get; set; }
        public Guid FoodPlanId { get; set; } = Guid.Empty;
        public string Email { get; set; } = string.Empty;
        public SharePermission Permission { get; set; } = SharePermission.Visning;
    }
}
