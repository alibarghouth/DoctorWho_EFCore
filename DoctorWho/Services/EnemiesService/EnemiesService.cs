using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EnemiesRepository;

namespace DoctorWho.Services.EnemiesService
{
    public class EnemiesService : IEnemiesService
    {
        private readonly IEnemiesRepository _enemiesRepository;
        private readonly IMapper _mapper;

        public EnemiesService(IEnemiesRepository enemiesRepository, IMapper mapper)
        {
            _enemiesRepository = enemiesRepository;
            _mapper = mapper;
        }

        public async Task<string> GetAllEnemiesNameByEpisodeId(int episodeId)
        {
            return await _enemiesRepository.GetAllEnemiesNameByEpisodeId(episodeId);
        }

        public async Task<string> AddEnemyAsync(EnemyRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description))
                return "all input is required";
            var enemy = _mapper.Map<Enemy>(request);
            var result = await _enemiesRepository.AddEnemyAsync(enemy);
            if (result is null)
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

        public async Task<Enemy?> GetEnemyById(int enemyId)
        {
            return await _enemiesRepository.GetEnemyById(enemyId);
        }
    }
}