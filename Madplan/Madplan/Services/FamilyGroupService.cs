using Madplan.Models;
using Madplan.Repository;

namespace Madplan.Services
{
    public class FamilyGroupService
    {
        private readonly FamilyGroupRepository _familyGroupRepository;

        public FamilyGroupService(FamilyGroupRepository familyGroupRepository)
        {
            _familyGroupRepository = familyGroupRepository;
        }

        public async Task Remove(Guid id)
        {
            await _familyGroupRepository.Delete(id);
        }

        public async Task Update(FamilyGroup fg)
        {
            await _familyGroupRepository.Update(fg);
        }

        public async Task<List<FamilyGroup>> GetAll()
        {
            var result = await _familyGroupRepository.GetAll();
            return result;
        }

        public async Task<FamilyGroup> GetById(Guid id)
        {
            var result = await _familyGroupRepository.GetById(id);
            return result;
        }

        public async Task<FamilyGroup> GetByFamilyId(Guid id)
        {
            var result = await _familyGroupRepository.GetByFamilyId(id);
            return result;
        }

        public async Task<List<FamilyGroup>> GetAllByFamilyId(Guid id)
        {
            var result = await _familyGroupRepository.GetAllByFamilyId(id);
            return result;
        }

        public async Task<List<FamilyGroup>> GetMemberOfByEmail(string email)
        {
            var result = await _familyGroupRepository.GetMemberOfByEmail(email);
            return result;
        }

        public async Task<List<FamilyGroup>> GetCreatedByUserId(Guid id)
        {
            var result = await _familyGroupRepository.GetCreatedByUserId(id);
            return result;
        }

        public async Task Add(FamilyGroup fg)
        {
            await _familyGroupRepository.Add(fg);
        }
    }
}
