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

        public async Task<IEnumerable<string>> GetAllEnemiesNameByEpisodeId(int id)
        {
            return await _dbContext.Enemies
                .Select(x => _dbContext.FnEnemies(id))
                .ToListAsync();
        }
    }
}
