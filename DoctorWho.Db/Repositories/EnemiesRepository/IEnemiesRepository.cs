using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EnemiesRepository
{
    public interface IEnemiesRepository
    {
        Task<string> GetAllEnemiesNameByEpisodeId(int episodeId);
        Task<Enemy> AddEnemyAsync(Enemy request);
        Task<bool> DeleteEnemyAsync(int enemyId);
        Task<bool> UpdateEnemyAsync(EnemyRequestModel request, int enemyId);
        Task<Enemy> GetEnemyById(int enemyId);
    }
}
