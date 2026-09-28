using Madplan.Models;
using Madplan.Models.Enums;

namespace Madplan.Authentication
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public AppUserSettings? Settings { get; set; }
        public List<ShoppingList> ShoppingLists { get; set; } = [];
        public List<FavoriteFood> FavoriteFoods { get; set; } = [];
    }
}
