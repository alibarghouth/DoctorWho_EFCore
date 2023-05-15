using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EpisodeCompanionRepository;
using DoctorWho.Exceptions;

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

    public async Task<EpisodeCompanionRequestModel> AddCompanionToEpisode(EpisodeCompanionRequestModel request)
    {
        if (request.CompanionId == 0 || request.EpisodeId == 0)
            throw new DoctorWhoException();
        var episodeCompanion = _mapper.Map<EpisodeCompanion>(request);
        var result = _mapper.Map<EpisodeCompanionRequestModel>(await _companionRepository.AddCompanionToEpisode(episodeCompanion));

        return result is null ? throw new NullReferenceException() : result;
    }
}