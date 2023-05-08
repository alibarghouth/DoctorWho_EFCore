using DoctorWho.Db.Context;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repository.EpisodesRepository
{
    public class EpisodesRepository : IEpisodesRepository
    {
        private readonly DoctorWhoCoreDbContext _dbContext;

        public EpisodesRepository(DoctorWhoCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ViewEpisodes> GetEpisodeUsingView()
        {
            return _dbContext.ViewEpisodes.ToList();
        }
    }
}
