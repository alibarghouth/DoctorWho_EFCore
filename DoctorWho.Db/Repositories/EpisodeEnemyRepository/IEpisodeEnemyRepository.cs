using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodeEnemyRepository;

public interface IEpisodeEnemyRepository
{
    Task<EpisodeEnemy> AddEnemyToEpisode(EpisodeEnemy request);
}