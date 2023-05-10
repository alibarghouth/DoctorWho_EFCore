using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EpisodesRepository;

namespace DoctorWho.Services.EpisodesService
{
    public class EpisodesService : IEpisodesService
    {
        private readonly IEpisodesRepository _episodesRepository;

        public EpisodesService(IEpisodesRepository episodesRepository)
        {
            _episodesRepository = episodesRepository;
        }

        public async Task<IEnumerable<ViewEpisodes>> GetEpisode()
        {
            return await _episodesRepository.GetEpisode();
        }
    }
}
