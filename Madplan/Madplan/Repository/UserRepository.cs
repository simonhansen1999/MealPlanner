using Madplan.Authentication;
using Madplan.Database;
using Microsoft.EntityFrameworkCore;

namespace Madplan.Repository
{
    public class UserRepository
    {
        private AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AppUser> GetById(Guid id)
        {
            var user = await _dbContext.Users.Include(x => x.Settings).Include(x => x.ShoppingLists).ThenInclude(x => x.AggregatedItems).Include(x => x.FavoriteFoods).FirstOrDefaultAsync(f => f.Id == id);
            return user ?? null!;
        }

        public async Task<List<AppUser>> GetAll()
        {
            var users = await _dbContext.Users.Include(x => x.Settings).Include(x => x.ShoppingLists).ThenInclude(x => x.AggregatedItems).Include(x => x.FavoriteFoods).ToListAsync();
            return users ?? null!;
        }

        public async Task Update(AppUser appUser)
        {
            if (_dbContext.Entry(appUser).State == EntityState.Detached)
            {
                _dbContext.Users.Attach(appUser);
            }

            _dbContext.Users.Update(appUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is not null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
