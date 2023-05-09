using DoctorWho.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repository.CompanionsRepository
{
    public class CompanionsRepository : ICompanionsRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;

        public CompanionsRepository(DoctorWhoCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> GetCompanionsByEpisodeIdUsingFun(int id)
        {
            return await _dbContext.Companions
                .Select(x => _dbContext.FnCompanions(id))
                .ToListAsync();
        }
    }
}
