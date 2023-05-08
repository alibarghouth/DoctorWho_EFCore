using DoctorWho.Db.Context;

namespace DoctorWho.Db.Repository.CompanionsRepository
{
    public class CompanionsRepository : ICompanionsRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;

        public CompanionsRepository(DoctorWhoCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<string> GetCompanionsByEpisodeIdUsingFun(int id)
        {
            return _dbContext.Companions
                .Select(x => _dbContext.FnCompanions(id))
                .ToList();
        }
    }
}
