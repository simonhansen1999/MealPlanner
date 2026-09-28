using Madplan.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Madplan.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public Guid IngredientGroupId { get; set; }
        [Required(ErrorMessage = "Ingredient name is required")]
        public string Name { get; set; } = string.Empty;
        [Range(0.1, double.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public UnitType Unit { get; set; }

        public Ingredient(double quantity, UnitType unit, string name = "")
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public Ingredient() { }
    }
}