using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodeEnemyRepository;

public class EpisodeEnemyRepository : IEpisodeEnemyRepository
{
    private readonly IMapper _mapper;
    private readonly DoctorWhoCoreDbContext _dbContext;

    public EpisodeEnemyRepository(IMapper mapper, DoctorWhoCoreDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<EpisodeEnemy?> AddEnemyToEpisode(EpisodeEnemyRequestModel request)
    {
        var episodeEnemy = _mapper.Map<EpisodeEnemy>(request);
        await _dbContext.EpisodeEnemies.AddAsync(episodeEnemy);
        await _dbContext.SaveChangesAsync();

        return episodeEnemy;
    }
}