using DoctorWho.Db.Context;
using DoctorWho.Db.Repositories.CompanionsRepository;
using Microsoft.EntityFrameworkCore;

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
    }
}
