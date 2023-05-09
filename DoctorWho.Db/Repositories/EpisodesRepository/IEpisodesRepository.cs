using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repository.EpisodesRepository
{
    public interface IEpisodesRepository
    {
        Task<IEnumerable<ViewEpisodes>> GetEpisodeUsingView();
    }
}
