using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodeCompanionRepository;

public class EpisodeCompanionRepository : IEpisodeCompanionRepository
{
    private readonly DoctorWhoCoreDbContext _dbContext;

    public EpisodeCompanionRepository(DoctorWhoCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EpisodeCompanion> AddCompanionToEpisode(EpisodeCompanion request)
    {
        await _dbContext.EpisodeCompanions.AddAsync(request);
        await _dbContext.SaveChangesAsync();

        return request;
    }
}