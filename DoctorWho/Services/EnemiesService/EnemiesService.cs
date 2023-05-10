using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EnemiesRepository;

namespace DoctorWho.Services.EnemiesService
{
    public class EnemiesService : IEnemiesService
    {
        private readonly IEnemiesRepository _enemiesRepository;

        public EnemiesService(IEnemiesRepository enemiesRepository)
        {
            _enemiesRepository = enemiesRepository;
        }

        public async Task<string> GetAllEnemiesNameByEpisodeId(int episodeId)
        {
            return await _enemiesRepository.GetAllEnemiesNameByEpisodeId(episodeId);
        }

        public async Task<string> AddEnemyAsync(EnemyRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description))
                return "all input is required";
            var enemy = await _enemiesRepository.AddEnemyAsync(request);
            if (enemy is null)
                return "failed";
            return "success";
        }

        public async Task<string> DeleteEnemyAsync(int enemyId)
        {
            if (enemyId == 0)
                return "failed";
            var result = await _enemiesRepository.DeleteEnemyAsync(enemyId);
            if (!result)
                return "failed";
            return "success";
        }

        public async Task<string> UpdateEnemyAsync(EnemyRequestModel request, int enemyId)
        {
            if (enemyId == 0)
                return "failed";
            var result = await _enemiesRepository.UpdateEnemyAsync(request, enemyId);
            if (!result)
                return "failed";
            return "success";
        }
    }
}