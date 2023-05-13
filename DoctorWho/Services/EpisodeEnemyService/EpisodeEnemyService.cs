using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EpisodeEnemyRepository;

namespace DoctorWho.Services.EpisodeEnemyService;

public class EpisodeEnemyService : IEpisodeEnemyService
{
    private readonly IEpisodeEnemyRepository _episodeEnemyRepository;
    private readonly IMapper _mapper;

    public EpisodeEnemyService(IEpisodeEnemyRepository episodeEnemyRepository, IMapper mapper)
    {
        _episodeEnemyRepository = episodeEnemyRepository;
        _mapper = mapper;
    }

    public async Task<string> AddEnemyToEpisode(EpisodeEnemyRequestModel request)
    {
        if(request.EnemyId == 0 || request.EpisodeId == 0)
            return "InValid input";
        var episodeEnemy = _mapper.Map<EpisodeEnemy>(request);
        var result = await _episodeEnemyRepository.AddEnemyToEpisode(episodeEnemy);
        
        if (result is null)
            return "failed";
        return "success";
    }
}