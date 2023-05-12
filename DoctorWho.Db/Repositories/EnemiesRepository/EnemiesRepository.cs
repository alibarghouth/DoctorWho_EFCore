using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EnemiesRepository
{
    public class EnemiesRepository : IEnemiesRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public EnemiesRepository(DoctorWhoCoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<string> GetAllEnemiesNameByEpisodeId(int episodeId)
        {
            return await  Task.Run(() => _dbContext.FnEnemies(episodeId));
        }

        public async Task<Enemy?> AddEnemyAsync(EnemyRequestModel request)
        {
            var enemy = _mapper.Map<Enemy>(request);
            await _dbContext.Enemies.AddAsync(enemy);
            await _dbContext.SaveChangesAsync();

            return enemy;
        }

        public async Task<bool> DeleteEnemyAsync(int enemyId)
        {
            var enemy = await FindEnemyById(enemyId);
            if (enemy is null)
                return false;
            _dbContext.Enemies.Remove(enemy);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEnemyAsync(EnemyRequestModel request, int enemyId)
        {
            var enemy = await FindEnemyById(enemyId);
            if (enemy is null)
                return false;
            if (!string.IsNullOrEmpty(request.Name))
                enemy.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Description))
                enemy.Description = request.Description;

            _dbContext.Enemies.Update(enemy);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Enemy?> GetEnemyById(int enemyId)
        {
            return await FindEnemyById(enemyId);
        }

        private async Task<Enemy?> FindEnemyById(int enemyId)
        {
            return await _dbContext.Enemies.FindAsync(enemyId);
        }
    }
}
