using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.CompanionsRepository
{
    public class CompanionsRepository : ICompanionsRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;

        public CompanionsRepository(DoctorWhoCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetCompanionsByEpisodeId(int episodeId)
        {
            return await Task.Run(() => _dbContext.FnCompanions(episodeId));
        }

        public async Task<Companion> AddCompanionAsync(Companion request)
        {
            await _dbContext.Companions.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return request;
        }

        public async Task<bool> DeleteCompanionAsync(int companionId)
        {
            var companion = await FindCompanionById(companionId) ?? throw new NullReferenceException();
            
            _dbContext.Companions.Remove(companion);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Companion> UpdateCompanionAsync(Companion request)
        {
            _dbContext.Companions.Update(request);
            await _dbContext.SaveChangesAsync();

            return request;
        }
        public async Task<Companion> GetCompanionById(int companionId)
        {
            return await FindCompanionById(companionId);
        }
        public async Task<Companion> FindCompanionById(int companionId)
        {
            return await _dbContext.Companions.FindAsync(companionId);
        }
    }
}