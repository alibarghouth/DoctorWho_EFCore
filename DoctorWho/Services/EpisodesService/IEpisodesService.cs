using DoctorWho.Db.Model;

namespace DoctorWho.Services.EpisodesService
{
    public interface IEpisodesService
    {
        Task<IEnumerable<ViewEpisodes>> GetEpisode();
    }
}
