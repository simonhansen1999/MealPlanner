using Madplan.Database;
using Madplan.Models;
using Microsoft.EntityFrameworkCore;

namespace Madplan.Repository
{
    public class FoodRepository
    {
        private AppDbContext _dbContext;

        public FoodRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Food food)
        {
            try
            {
                await _dbContext.Foods.AddAsync(food);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }
        }

        public async Task Remove(Food food)
        {
            try
            {
                _dbContext.Foods.Remove(food);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }
        }

        public async Task<List<Food>> GetAll()
        {
            var foods = await _dbContext.Foods.Include(f => f.Recipe).ThenInclude(r => r!.IngredientGroups).ThenInclude(g => g.Ingredients).ToListAsync();
            return foods;
        }

        public async Task<Food> GetById(Guid id)
        {
            var food = await _dbContext.Foods.Include(f => f.Recipe).ThenInclude(r => r!.IngredientGroups).ThenInclude(g => g.Ingredients).FirstOrDefaultAsync(f => f.Id == id);
            return food ?? null!;
        }

        public async Task<Food> GetByName(string name)
        {
            var food = await _dbContext.Foods.Include(f => f.Recipe).ThenInclude(r => r!.IngredientGroups).ThenInclude(g => g.Ingredients).FirstOrDefaultAsync(f => f.Name.Equals(name));
            return food ?? null!;
        }

        public async Task Update(Food food, string oldName = "")
        {
            try
            {
                if (_dbContext.Entry(food).State == EntityState.Detached)
                {
                    _dbContext.Foods.Attach(food);
                }

                _dbContext.Foods.Update(food);

                // If renaming, update DailyFood entries safely on tracked FoodPlan instances - bad structure in DB (breaks normalization :()
                if (!string.IsNullOrWhiteSpace(oldName))
                {
                    var foodPlans = _dbContext.FoodPlans
                        .Include(fp => fp.Foods)
                        .Where(fp => fp.Foods.Any(df => df.Name == oldName))
                        .ToList();

                    foreach (var plan in foodPlans)
                    {
                        foreach (var daily in plan.Foods.Where(df => df.Name == oldName))
                        {
                            daily.Name = food.Name;
                        }
                    }
                    // no UpdateRange on detached instances
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var food = await _dbContext.Foods.FindAsync(id);
                if (food is not null)
                {
                    _dbContext.Foods.Remove(food);
                    await _dbContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}