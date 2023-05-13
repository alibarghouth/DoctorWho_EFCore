using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EpisodeCompanionRepository;

namespace DoctorWho.Services.EpisodeCompanionService;

public class EpisodeCompanionService : IEpisodeCompanionService
{
    private readonly IEpisodeCompanionRepository _companionRepository;
    private readonly IMapper _mapper;

    public EpisodeCompanionService(IEpisodeCompanionRepository companionRepository, IMapper mapper)
    {
        _companionRepository = companionRepository;
        _mapper = mapper;
    }

    public async Task<string> AddCompanionToEpisode(EpisodeCompanionRequestModel request)
    {
        if(request.CompanionId == 0 || request.EpisodeId == 0)
            return "InValid input";
        var episodeCompanion = _mapper.Map<EpisodeCompanion>(request);
        var result = await _companionRepository.AddCompanionToEpisode(episodeCompanion);
        
        if (result is null)
            return "failed";
        return "success";
    }
}