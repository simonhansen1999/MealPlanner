using Madplan.Authentication;
using Madplan.Repository;

namespace Madplan.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Remove(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public async Task Update(AppUser appUser)
        {
            await _userRepository.Update(appUser);
        }

        public async Task<List<AppUser>> GetAll()
        {
            var result = await _userRepository.GetAll();
            return result;
        }

        public async Task<AppUser> GetById(Guid id)
        {
            var result = await _userRepository.GetById(id);
            return result;
        }
    }
}
