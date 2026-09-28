using Madplan.Database;
using Madplan.Models;
using Microsoft.EntityFrameworkCore;

namespace Madplan.Repository
{
    public class FamilyGroupRepository
    {
        private AppDbContext _dbContext;

        public FamilyGroupRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FamilyGroup> GetById(Guid id)
        {
            var r = await _dbContext.FamilyGroups.Include(x => x.Members).FirstOrDefaultAsync(f => f.Id == id);
            return r ?? null!;
        }

        public async Task<List<FamilyGroup>> GetCreatedByUserId(Guid id)
        {
            var r = await _dbContext.FamilyGroups.Include(x => x.Members).Where(f => f.CreatedBy == id).ToListAsync();
            return r ?? null!;
        }

        public async Task<List<FamilyGroup>> GetMemberOfByEmail(string email)
        {
            var r = await _dbContext.FamilyGroups.Include(x => x.Members).Where(f => f.Members.Any(x => x.Email == email.ToLower())).ToListAsync();

            return r ?? null!;
        }

        public async Task<FamilyGroup> GetByFamilyId(Guid id)
        {
            var r = await _dbContext.FamilyGroups.Include(x => x.Members).FirstOrDefaultAsync(f => f.Id == id);
            return r ?? null!;
        }

        public async Task<List<FamilyGroup>> GetAllByFamilyId(Guid id)
        {
            var r = await _dbContext.FamilyGroups.Include(x => x.Members).Where(f => f.Members.Any(x => x.FamilyId == id)).ToListAsync();
            return r ?? null!;
        }

        public async Task<List<FamilyGroup>> GetAll()
        {
            var r = await _dbContext.FamilyGroups.Include(x => x.Members).ToListAsync();
            return r ?? null!;
        }

        public async Task Add(FamilyGroup fg)
        {
            try
            {
                await _dbContext.FamilyGroups.AddAsync(fg);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) { }
        }

        public async Task Update(FamilyGroup fg)
        {
            if (_dbContext.Entry(fg).State == EntityState.Detached)
            {
                _dbContext.FamilyGroups.Attach(fg);
            }

            _dbContext.Update(fg);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var r = await _dbContext.FamilyGroups.FindAsync(id);
            if (r is not null)
            {
                _dbContext.FamilyGroups.Remove(r);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
