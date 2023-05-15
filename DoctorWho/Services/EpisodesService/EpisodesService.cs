using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.EpisodesRepository;
using DoctorWho.Exceptions;

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

        public async Task<EpisodeRequestModel> AddEpisodeAsync(EpisodeRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Notes) || string.IsNullOrEmpty(request.Title)
                || string.IsNullOrEmpty(request.Episodetype))
                throw new DoctorWhoException();
            var episode = _mapper.Map<Episode>(request);
            var result = _mapper.Map<EpisodeRequestModel>(await _episodesRepository.AddEpisodeAsync(episode));

            return result is null ? throw new NullReferenceException() : result;
        }

        public async Task<bool> DeleteEpisodeAsync(int episodeId)
        {
            if (episodeId == 0)
                return false;
            var result = await _episodesRepository.DeleteEpisodeAsync(episodeId);
            if (!result)
                return false;
            return true;
        }

        public async Task<EpisodeRequestModel> UpdateEpisodeAsync(EpisodeRequestModel request, int episodeId)
        {
            if (episodeId == 0)
                throw new DoctorWhoException();

            var episode = await _episodesRepository.FindEpisodeById(episodeId);
            if (!string.IsNullOrEmpty(request.Title))
                episode.Title = request.Title;
            if (!string.IsNullOrEmpty(request.Notes))
                episode.Notes = request.Notes;
            if (!string.IsNullOrEmpty(request.Episodetype))
                episode.Episodetype = request.Episodetype;

            var result = _mapper.Map<EpisodeRequestModel>(await _episodesRepository.UpdateEpisodeAsync(episode));

            return result is null ? throw new NullReferenceException() : result;
        }
    }
}
