using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EpisodeEnemyRepository;
using DoctorWho.Exceptions;

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

    public async Task<EpisodeEnemyRequestModel> AddEnemyToEpisode(EpisodeEnemyRequestModel request)
    {
        if (request.EnemyId == 0 || request.EpisodeId == 0)
            throw new DoctorWhoException();
        var episodeEnemy = _mapper.Map<EpisodeEnemy>(request);
        var result = _mapper.Map<EpisodeEnemyRequestModel>(await _episodeEnemyRepository.AddEnemyToEpisode(episodeEnemy));

        return result is null ? throw new NullReferenceException() : result;
    }
}