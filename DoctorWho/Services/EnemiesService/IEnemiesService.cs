using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Services.EnemiesService
{
    public interface IEnemiesService
    {
        Task<string> GetAllEnemiesNameByEpisodeId(int episodeId);
        Task<string> AddEnemyAsync(EnemyRequestModel request);
        Task<string> DeleteEnemyAsync(int enemyId);
        Task<string> UpdateEnemyAsync(EnemyRequestModel request, int enemyId);
    }
}