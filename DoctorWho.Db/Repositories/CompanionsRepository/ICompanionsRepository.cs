using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.CompanionsRepository
{
    public interface ICompanionsRepository
    {
         Task<string> GetCompanionsByEpisodeId(int episodeId);
    }
}
