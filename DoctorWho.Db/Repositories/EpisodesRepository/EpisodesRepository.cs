using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories.EpisodesRepository
{
    public class EpisodesRepository : IEpisodesRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;
        public EpisodesRepository(DoctorWhoCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<EpisodesView>> GetEpisode()
        {
            return await _dbContext.EpisodesView.ToListAsync();
        }
        public async Task<Episode?> AddEpisodeAsync(Episode request)
        {
            await _dbContext.Episodes.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return request;
        }
        public async Task<bool> DeleteEpisodeAsync(int enemyId)
        {
            var episode = await FindEpisodeById(enemyId);
            _dbContext.Episodes.Remove(episode);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateEpisodeAsync(EpisodeRequestModel request, int enemyId)
        {
            var episode = await FindEpisodeById(enemyId);
            
            if (!string.IsNullOrEmpty(request.Title))
                episode.Title = request.Title;
            if (!string.IsNullOrEmpty(request.Notes))
                episode.Notes = request.Notes;
            if (!string.IsNullOrEmpty(request.Episodetype))
                episode.Episodetype = request.Episodetype;
            
            _dbContext.Episodes.Update(episode);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        private async Task<Episode> FindEpisodeById(int episodeId)
        {
            return await _dbContext.Episodes.FindAsync(episodeId);
        }
    }
}
