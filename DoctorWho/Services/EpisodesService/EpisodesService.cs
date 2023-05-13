using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EpisodesRepository;

namespace DoctorWho.Services.EpisodesService
{
    public class EpisodesService : IEpisodesService
    {
        private readonly IEpisodesRepository _episodesRepository;
        private readonly IMapper _mapper;

        public EpisodesService(IEpisodesRepository episodesRepository, IMapper mapper)
        {
            _episodesRepository = episodesRepository;
            _mapper = mapper;
        }

        public async Task<List<EpisodesView>> GetEpisode()
        {
            return await _episodesRepository.GetEpisode();
        }

        public async Task<string> AddEpisodeAsync(EpisodeRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Notes) || string.IsNullOrEmpty(request.Title)
                || string.IsNullOrEmpty(request.Episodetype))
                return "all input is required";
            var episode = _mapper.Map<Episode>(request);
            var result = await _episodesRepository.AddEpisodeAsync(episode);
            
            if (result is null)
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
            
            var episode = await _episodesRepository.FindEpisodeById(episodeId);
            if (!string.IsNullOrEmpty(request.Title))
                episode.Title = request.Title;
            if (!string.IsNullOrEmpty(request.Notes))
                episode.Notes = request.Notes;
            if (!string.IsNullOrEmpty(request.Episodetype))
                episode.Episodetype = request.Episodetype;
            
            var result = await _episodesRepository.UpdateEpisodeAsync(episode);
            if (!result)
                return "failed";
            return "success";
        }
    }
}
