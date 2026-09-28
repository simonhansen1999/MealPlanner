using Madplan.Models;
using Madplan.Repository;

namespace Madplan.Services
{
    public class FoodService
    {
        private readonly FoodRepository _foodRepository;

        public FoodService(FoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task Add(Food food)
        {
            await _foodRepository.Add(food);
        }

        public async Task Remove(Food food)
        {
            await _foodRepository.Remove(food);
        }

        public async Task<List<Food>> GetAllFoods()
        {
            var result = await _foodRepository.GetAll();
            return result;
        }

        public async Task<Food> GetFoodById(Guid id)
        {
            var result = await _foodRepository.GetById(id);
            return result;
        }

        public async Task<Food> GetFoodByName(string name)
        {
            var result = await _foodRepository.GetByName(name);
            return result;
        }

        public async Task Update(Food food, string oldName = "")
        {
            try
            {
                await _foodRepository.Update(food, oldName);
            } catch (Exception) { }
        }
    }
}
