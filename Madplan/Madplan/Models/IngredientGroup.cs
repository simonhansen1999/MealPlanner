using System.ComponentModel.DataAnnotations;

namespace Madplan.Models
{
    public class IngredientGroup
    {
        public Guid Id { get; set; } 
        public Guid RecipeId { get; set; }
        [Required(ErrorMessage = "Group name is required")]
        public string Name { get; set; } = string.Empty;
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public IngredientGroup() { }
    }
}
