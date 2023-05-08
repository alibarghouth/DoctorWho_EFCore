using DoctorWho.Db.Model;

namespace DoctorWho.Services.EpisodesService
{
    public interface IEpisodesService
    {
        IEnumerable<ViewEpisodes> GetEpisodeUsingView();
    }
}
