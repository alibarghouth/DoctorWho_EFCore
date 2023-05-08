using DoctorWho.Db.Model;
using DoctorWho.Db.Repository.EpisodesRepository;

namespace DoctorWho.Services.EpisodesService
{
    public class EpisodesService : IEpisodesService
    {
        private readonly IEpisodesRepository _episodesRepository;

        public EpisodesService(IEpisodesRepository episodesRepository)
        {
            _episodesRepository = episodesRepository;
        }

        public IEnumerable<ViewEpisodes> GetEpisodeUsingView()
        {
            return _episodesRepository.GetEpisodeUsingView();
        }
    }
}
