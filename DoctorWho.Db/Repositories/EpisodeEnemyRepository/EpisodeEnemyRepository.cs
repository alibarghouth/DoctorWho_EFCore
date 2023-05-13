using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodeEnemyRepository;

public class EpisodeEnemyRepository : IEpisodeEnemyRepository
{
    private readonly DoctorWhoCoreDbContext _dbContext;

    public EpisodeEnemyRepository(DoctorWhoCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EpisodeEnemy> AddEnemyToEpisode(EpisodeEnemy request)
    {
        await _dbContext.EpisodeEnemies.AddAsync(request);
        await _dbContext.SaveChangesAsync();

        return request;
    }
}