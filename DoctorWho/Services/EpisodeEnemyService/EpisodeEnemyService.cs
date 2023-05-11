using DoctorWho.Db.DTOS;
using DoctorWho.Db.Repositories.EpisodeEnemyRepository;

namespace DoctorWho.Services.EpisodeEnemyService;

public class EpisodeEnemyService : IEpisodeEnemyService
{
    private readonly IEpisodeEnemyRepository _episodeEnemyRepository;

    public EpisodeEnemyService(IEpisodeEnemyRepository episodeEnemyRepository)
    {
        _episodeEnemyRepository = episodeEnemyRepository;
    }

    public async Task<string> AddEnemyToEpisode(EpisodeEnemyRequestModel request)
    {
        if(request.EnemyId == 0 || request.EpisodeId == 0)
            return "InValid input";
        var episodeEnemy = await _episodeEnemyRepository.AddEnemyToEpisode(request);
        if (episodeEnemy is null)
            return "failed";
        return "success";
    }
}