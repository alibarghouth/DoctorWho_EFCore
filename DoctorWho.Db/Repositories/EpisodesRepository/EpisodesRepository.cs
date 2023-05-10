using DoctorWho.Db.Context;
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

        public async Task<IEnumerable<ViewEpisodes>> GetEpisode()
        {
            return await _dbContext.EpisodesView.ToListAsync();
        }
    }
}
