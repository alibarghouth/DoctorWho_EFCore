using DoctorWho.Db.Repository.EnemiesRepository;

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
    }
}
