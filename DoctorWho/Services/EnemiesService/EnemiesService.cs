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

        public IEnumerable<string> GetAllEnemiesNameByEpisodeId(int id)
        {
            return _enemiesRepository.GetAllEnemiesNameByEpisodeId(id);
        }
    }
}
