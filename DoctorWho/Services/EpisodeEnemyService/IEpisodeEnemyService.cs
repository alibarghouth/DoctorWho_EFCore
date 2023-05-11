using DoctorWho.Db.DTOS;

namespace DoctorWho.Services.EpisodeEnemyService;

public interface IEpisodeEnemyService
{
    Task<string> AddEnemyToEpisode(EpisodeEnemyRequestModel request);
}