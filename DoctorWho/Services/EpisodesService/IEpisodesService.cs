using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Services.EpisodesService
{
    public interface IEpisodesService
    {
        Task<IEnumerable<EpisodesView>> GetEpisode();
        Task<string> AddEpisodeAsync(EpisodeRequestModel request);
        Task<string> DeleteEpisodeAsync(int episodeId);
        Task<string> UpdateEpisodeAsync(EpisodeRequestModel request, int episodeId);
    }
}
