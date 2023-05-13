using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodeCompanionRepository;

public interface IEpisodeCompanionRepository
{
    Task<EpisodeCompanion> AddCompanionToEpisode(EpisodeCompanion request);
}