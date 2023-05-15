using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodesRepository
{
    public interface IEpisodesRepository
    {
        Task<List<EpisodesView>> GetEpisode();
        Task<Episode> AddEpisodeAsync(Episode request);
        Task<bool> DeleteEpisodeAsync(int episodeId);
        Task<Episode> UpdateEpisodeAsync(Episode request);
        Task<Episode> FindEpisodeById(int episodeId);
    }
}
