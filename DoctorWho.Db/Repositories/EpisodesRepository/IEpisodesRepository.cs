using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repository.EpisodesRepository
{
    public interface IEpisodesRepository
    {
        IEnumerable<ViewEpisodes> GetEpisodeUsingView();
    }
}
