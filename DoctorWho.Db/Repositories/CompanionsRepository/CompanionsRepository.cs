using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;


namespace DoctorWho.Db.Repositories.CompanionsRepository
{
    public class CompanionsRepository : ICompanionsRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanionsRepository(DoctorWhoCoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<string> GetCompanionsByEpisodeId(int episodeId)
        {
            return await Task.Run(() => _dbContext.FnCompanions(episodeId));
        }

        public async Task<Companion?> AddCompanionAsync(CompanionRequestModel request)
        {
            var companion = _mapper.Map<Companion>(request);
            await _dbContext.Companions.AddAsync(companion);
            await _dbContext.SaveChangesAsync();

            return companion;
        }

        public async Task<bool> DeleteCompanionAsync(int companionId)
        {
            var companion = await FindCompanionById(companionId);
            if (companion is null)
                return false;

            _dbContext.Companions.Remove(companion);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCompanionAsync(CompanionRequestModel request, int companionId)
        {
            var companion = await FindCompanionById(companionId);
            if (companion is null)
                return false;
            if (!string.IsNullOrEmpty(request.Name))
                companion.Name = request.Name;
            if (!string.IsNullOrEmpty(request.WhoPlayed))
                companion.WhoPlayed = request.WhoPlayed;
            _dbContext.Companions.Update(companion);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        private async Task<Companion?> FindCompanionById(int companionId)
        {
            var companion = await _dbContext.Companions.FindAsync(companionId);

            return companion;
        }
        public async Task<Companion?> GetCompanionById(int companionId)
        {
            return await FindCompanionById(companionId);
        }
    }
}