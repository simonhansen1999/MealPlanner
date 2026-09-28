using Madplan.Database;
using Madplan.Models;
using Madplan.Services;
using Microsoft.EntityFrameworkCore;

namespace Madplan.Repository
{
    public class FoodPlanRepository
    {
        private readonly AppDbContext _dbContext;
        private FamilyGroupService _familyGroupHelper;

        public FoodPlanRepository(AppDbContext dbContext, FamilyGroupService familyGroupHelper)
        {
            _dbContext = dbContext;
            _familyGroupHelper = familyGroupHelper;
        }

        public async Task Add(FoodPlan food)
        {
            try
            {
                await _dbContext.FoodPlans.AddAsync(food);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) { }
        }

        public async Task Remove(FoodPlan food)
        {
            try
            {
                _dbContext.FoodPlans.Remove(food);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) { }
        }

        public async Task<List<FoodPlan>> GetAll()
        {
            return await _dbContext.FoodPlans
                .Include(f => f.Foods)
                .Include(f => f.SharedWith)
                .Include(f => f.SharedWithFamilyGroups)
                .ThenInclude(f => f.IndividualPermissions)
                .ToListAsync();
        }

        public async Task<FoodPlan> GetById(Guid id)
        {
            return await _dbContext.FoodPlans
                .Include(f => f.Foods)
                .Include(f => f.SharedWith)
                .Include(f => f.SharedWithFamilyGroups)
                .ThenInclude(f => f.IndividualPermissions)
                .FirstOrDefaultAsync(f => f.Id == id) ?? null!;
        }

        public async Task<List<FoodPlan>> GetByCreatedBy(string id)
        {
            return await _dbContext.FoodPlans
                .Include(f => f.Foods)
                .Include(f => f.SharedWith)
                .Include(f => f.SharedWithFamilyGroups)
                .ThenInclude(f => f.IndividualPermissions)
                .Where(f => f.CreatedBy == id)
                .ToListAsync();
        }

        public async Task<List<FoodPlan>> GetSharedWithFamilyGroupsByFoodPlanId(Guid id)
        {
            return await _dbContext.FoodPlans
                .Include(f => f.Foods)
                .Include(f => f.SharedWith)
                .Include(f => f.SharedWithFamilyGroups)
                .ThenInclude(f => f.IndividualPermissions)
                .Where(f => f.SharedWithFamilyGroups.Any(x => x.FoodPlanId == id))
                .ToListAsync();
        }

        public async Task<List<FoodPlan>> GetByEmail(string email)
        {
            // 1️⃣ Get all family groups the user belongs to
            var familyGroupIds = (await _familyGroupHelper.GetMemberOfByEmail(email))
                .Select(fg => fg.Id)
                .ToList();

            // 2️⃣ Get food plans shared directly OR via those family groups
            return await _dbContext.FoodPlans
                .AsNoTracking()
                .Include(f => f.Foods)
                .Include(f => f.SharedWith)
                .Include(f => f.SharedWithFamilyGroups)
                    .ThenInclude(fg => fg.IndividualPermissions)
                .Where(f =>
                    // Direct share
                    f.SharedWith.Any(sw => sw.Email == email)

                    // Family group share
                    || f.SharedWithFamilyGroups.Any(fg =>
                        familyGroupIds.Contains(fg.FamilyGroupId)
                    )
                )
                .ToListAsync();
        }



        public async Task Update(FoodPlan food)
        {
            if (_dbContext.Entry(food).State == EntityState.Detached)
            {
                _dbContext.FoodPlans.Attach(food);
            }

            _dbContext.FoodPlans.Update(food);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var food = await _dbContext.FoodPlans.FindAsync(id);
                if (food is not null)
                {
                    _dbContext.FoodPlans.Remove(food);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
