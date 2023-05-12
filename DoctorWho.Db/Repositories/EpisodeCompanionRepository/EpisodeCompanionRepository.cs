using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodeCompanionRepository;

public class EpisodeCompanionRepository : IEpisodeCompanionRepository
{
    private readonly DoctorWhoCoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public EpisodeCompanionRepository(DoctorWhoCoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<EpisodeCompanion?> AddCompanionToEpisode(EpisodeCompanionRequestModel request)
    {
        var episodeCompanion = _mapper.Map<EpisodeCompanion>(request);
        await _dbContext.EpisodeCompanions.AddAsync(episodeCompanion);
        await _dbContext.SaveChangesAsync();

        return episodeCompanion;
    }
}