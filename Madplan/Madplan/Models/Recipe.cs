using System.ComponentModel.DataAnnotations;

namespace Madplan.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public Guid FoodId { get; set; }
        [Required(ErrorMessage = "Instructions are required")]
        public string Instructions { get; set; } = string.Empty;

        // Grouped ingredients
        public List<IngredientGroup> IngredientGroups { get; set; } = new List<IngredientGroup>();

        public TimeSpan PreparationTime { get; set; }
        public TimeSpan CookingTime { get; set; }
        public double NumberOfServings { get; set; } = 1;

        public Recipe() { }
    }
}
