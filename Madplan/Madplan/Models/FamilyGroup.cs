namespace Madplan.Models
{
    public class FamilyGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public List<FamilyMember> Members { get; set; } = new();
    }
}
