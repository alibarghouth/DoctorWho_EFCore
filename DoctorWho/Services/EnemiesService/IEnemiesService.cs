using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Services.EnemiesService
{
    public interface IEnemiesService
    {
        Task<string> GetAllEnemiesNameByEpisodeId(int episodeId);
        Task<EnemyRequestModel> AddEnemyAsync(EnemyRequestModel request);
        Task<bool> DeleteEnemyAsync(int enemyId);
        Task<EnemyRequestModel> UpdateEnemyAsync(EnemyRequestModel request, int enemyId);
        Task<Enemy> GetEnemyById(int enemyId);

    }
}