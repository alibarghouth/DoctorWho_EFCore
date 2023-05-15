using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Services.EpisodesService
{
    public interface IEpisodesService
    {
        Task<List<EpisodesView>> GetEpisode();
        Task<EpisodeRequestModel> AddEpisodeAsync(EpisodeRequestModel request);
        Task<bool> DeleteEpisodeAsync(int episodeId);
        Task<EpisodeRequestModel> UpdateEpisodeAsync(EpisodeRequestModel request, int episodeId);
    }
}
