using DoctorWho.Db.Context;

namespace DoctorWho.Db.Repository.EnemiesRepository
{
    public class EnemiesRepository : IEnemiesRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;

        public EnemiesRepository(DoctorWhoCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<string> GetAllEnemiesNameByEpisodeId(int id)
        {
            return _dbContext.Enemies
                .Select(x => _dbContext.FnEnemies(id))
                .ToList();
        }
    }
}
