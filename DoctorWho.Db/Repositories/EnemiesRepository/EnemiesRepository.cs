using DoctorWho.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repository.EnemiesRepository
{
    public class EnemiesRepository : IEnemiesRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;

        public EnemiesRepository(DoctorWhoCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetAllEnemiesNameByEpisodeId(int episodeId)
        {
            return await  Task.Run(() => _dbContext.FnEnemies(episodeId));
        }
    }
}
