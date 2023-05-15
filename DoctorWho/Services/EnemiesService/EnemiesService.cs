using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EnemiesRepository;
using DoctorWho.Exceptions;

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

        public async Task<EnemyRequestModel> AddEnemyAsync(EnemyRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description))
                throw new DoctorWhoException();
            var enemy = _mapper.Map<Enemy>(request);
            var result = _mapper.Map<EnemyRequestModel>(await _enemiesRepository.AddEnemyAsync(enemy));

            return result is null ? throw new NullReferenceException() : result;
        }

        public async Task<bool> DeleteEnemyAsync(int enemyId)
        {
            if (enemyId == 0)
                return false;
            var result = await _enemiesRepository.DeleteEnemyAsync(enemyId);
            if (!result)
                return false;
            return true;
        }

        public async Task<EnemyRequestModel> UpdateEnemyAsync(EnemyRequestModel request, int enemyId)
        {
            if (enemyId == 0)
                throw new DoctorWhoException();
            var enemy = await _enemiesRepository.FindEnemyById(enemyId);

            if (!string.IsNullOrEmpty(request.Name))
                enemy.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Description))
                enemy.Description = request.Description;

            var result = _mapper.Map<EnemyRequestModel>(await _enemiesRepository.UpdateEnemyAsync(enemy));
            return result is null ? throw new NullReferenceException() : result;
        }

        public async Task<Enemy> GetEnemyById(int enemyId)
        {
            return await _enemiesRepository.GetEnemyById(enemyId);
        }
    }
}