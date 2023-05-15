using DoctorWho.Db.DTOS;

namespace DoctorWho.Services.EpisodeEnemyService;

public interface IEpisodeEnemyService
{
    Task<EpisodeEnemyRequestModel> AddEnemyToEpisode(EpisodeEnemyRequestModel request);
}