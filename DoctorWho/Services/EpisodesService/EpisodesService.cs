using DoctorWho.Db.DTOS;
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

        public async Task<IEnumerable<EpisodesView>> GetEpisode()
        {
            return await _episodesRepository.GetEpisode();
        }

        public async Task<string> AddEpisodeAsync(EpisodeRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Notes) || string.IsNullOrEmpty(request.Title)
                || string.IsNullOrEmpty(request.Episodetype))
                return "all input is required";
            var episode = await _episodesRepository.AddEpisodeAsync(request);
            if (episode is null)
                return "failed";
            return "success";
        }

        public async Task<string> DeleteEpisodeAsync(int episodeId)
        {
            if (episodeId == 0)
                return "failed";
            var result = await _episodesRepository.DeleteEpisodeAsync(episodeId);
            if (!result)
                return "failed";
            return "success";
        }

        public async Task<string> UpdateEpisodeAsync(EpisodeRequestModel request, int episodeId)
        {
            if (episodeId == 0)
                return "failed";
            var result = await _episodesRepository.UpdateEpisodeAsync(request, episodeId);
            if (!result)
                return "failed";
            return "success";
        }
    }
}
