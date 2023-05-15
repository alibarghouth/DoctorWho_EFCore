using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Services.EpisodeCompanionService;

public interface IEpisodeCompanionService
{
    Task<EpisodeCompanionRequestModel> AddCompanionToEpisode(EpisodeCompanionRequestModel request);
}