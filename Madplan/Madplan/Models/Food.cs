using Madplan.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Madplan.Models
{
    public class Food
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        [Required(ErrorMessage = "Food name is required")]
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
        public Recipe? Recipe { get; set; }
        public FoodCategory Category { get; set; } = FoodCategory.Pasta;

        public Food(string name, string createdBy, string description)
        {
            Name = name;
            CreatedBy = createdBy;
            Description = description;
        }

        public Food(string name, string description, string createdBy, Recipe recipe) : this(name, createdBy, description)
        {
            Recipe = recipe;
        }

        public Food() { }
    }
}
