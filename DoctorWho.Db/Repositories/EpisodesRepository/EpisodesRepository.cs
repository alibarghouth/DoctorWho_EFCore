using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories.EpisodesRepository
{
    public class EpisodesRepository : IEpisodesRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public EpisodesRepository(DoctorWhoCoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EpisodesView>> GetEpisode()
        {
            return await _dbContext.EpisodesView.ToListAsync();
        }
        public async Task<Episode?> AddEpisodeAsync(EpisodeRequestModel request)
        {
            var episode = _mapper.Map<Episode>(request);
            await _dbContext.Episodes.AddAsync(episode);
            
            return episode;
        }
        public async Task<bool> DeleteEpisodeAsync(int enemyId)
        {
            var episode = await FindEpisodeById(enemyId);
            if (episode is null)
                return false;
            _dbContext.Episodes.Remove(episode);
            
            return true;
        }
        public async Task<bool> UpdateEpisodeAsync(EpisodeRequestModel request, int enemyId)
        {
            var episode = await FindEpisodeById(enemyId);
            if (episode is null)
                return false;
            if (!string.IsNullOrEmpty(request.Title))
                episode.Title = request.Title;
            if (!string.IsNullOrEmpty(request.Notes))
                episode.Notes = request.Notes;
            if (!string.IsNullOrEmpty(request.Episodetype))
                episode.Episodetype = request.Episodetype;
            
            _dbContext.Episodes.Update(episode);
            
            return true;
        }
        private async Task<Episode?> FindEpisodeById(int episodeId)
        {
            return await _dbContext.Episodes.FindAsync(episodeId);
        }
    }
}
