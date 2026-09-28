using Madplan.Models.Enums;

namespace Madplan.Models
{
    public class FamilyMember
    {
        public Guid Id { get; set; }
        public Guid FamilyId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
