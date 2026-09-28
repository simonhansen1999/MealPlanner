using Madplan.Models.Enums;

namespace Madplan.Models
{
    public class IndividualPermission
    {
        public Guid Id { get; set; }
        public Guid FoodPlanFamilyGroupShareId { get; set; }
        public SharePermission SharePermission { get; set; } = SharePermission.Visning;
        public string Email { get; set; } = string.Empty;
    }
}
