using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.EpisodesRepository
{
    public interface IEpisodesRepository
    {
        Task<IEnumerable<ViewEpisodes>> GetEpisode();
    }
}
