using DoctorWho.Db.DTOS;
using DoctorWho.Db.Repositories.EpisodeCompanionRepository;

namespace DoctorWho.Services.EpisodeCompanionService;

public class EpisodeCompanionService : IEpisodeCompanionService
{
    private readonly IEpisodeCompanionRepository _companionRepository;

    public EpisodeCompanionService(IEpisodeCompanionRepository companionRepository)
    {
        _companionRepository = companionRepository;
    }

    public async Task<string> AddCompanionToEpisode(EpisodeCompanionRequestModel request)
    {
        if(request.CompanionId == 0 || request.EpisodeId == 0)
            return "InValid input";
        var episodeEnemy = await _companionRepository.AddCompanionToEpisode(request);
        if (episodeEnemy is null)
            return "failed";
        return "success";
    }
}