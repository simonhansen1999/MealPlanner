using System.ComponentModel.DataAnnotations.Schema;

namespace Madplan.Models
{
    public class FoodPlanFamilyGroupShare
    {
        public Guid Id { get; set; }

        public Guid FoodPlanId { get; set; }
        public Guid FamilyGroupId { get; set; }
        public List<IndividualPermission> IndividualPermissions { get; set; } = [];

        [NotMapped]
        public bool IsExpanded { get; set; } = false;
    }
}
