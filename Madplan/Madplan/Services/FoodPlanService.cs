using Madplan.Models;
using Madplan.Repository;

namespace Madplan
{
    public class FoodPlanService
    {
        private readonly FoodPlanRepository _foodplanRepository;

        public FoodPlanService(FoodPlanRepository foodplanRepository)
        {
            _foodplanRepository = foodplanRepository;
        }

        public async Task Add(FoodPlan food)
        {
            await _foodplanRepository.Add(food);
        }

        public async Task Remove(FoodPlan food)
        {
            await _foodplanRepository.Remove(food);
        }

        public async Task<List<FoodPlan>> GetAll()
        {
            var result = await _foodplanRepository.GetAll();
            return result;
        }

        public async Task<FoodPlan> GetById(Guid id)
        {
            var result = await _foodplanRepository.GetById(id);
            return result;
        }

        public async Task<List<FoodPlan>> GetByCreatedBy(string id)
        {
            var result = await _foodplanRepository.GetByCreatedBy(id);
            return result;
        }

        public async Task<List<FoodPlan>> GetSharedWithFamilyGroupsByFoodPlanId(Guid id)
        {
            var result = await _foodplanRepository.GetSharedWithFamilyGroupsByFoodPlanId(id);
            return result;
        }

        public async Task<List<FoodPlan>> GetByEmail(string email)
        {
            var result = await _foodplanRepository.GetByEmail(email);
            return result;
        }

        public async Task Update(FoodPlan food)
        {
            await _foodplanRepository.Update(food);
        }
    }
}
