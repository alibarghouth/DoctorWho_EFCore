using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodesRepository
{
    public interface IEpisodesRepository
    {
        Task<IEnumerable<EpisodesView>> GetEpisode();
        Task<Episode?> AddEpisodeAsync(EpisodeRequestModel request);
        Task<bool> DeleteEpisodeAsync(int enemyId);
        Task<bool> UpdateEpisodeAsync(EpisodeRequestModel request, int enemyId);
    }
}
