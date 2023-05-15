using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.CompanionsRepository
{
    public interface ICompanionsRepository
    {
         Task<string> GetCompanionsByEpisodeId(int episodeId);
         Task<Companion> AddCompanionAsync(Companion request);
         Task<bool> DeleteCompanionAsync(int companionId);
         Task<Companion> UpdateCompanionAsync(Companion request);
         Task<Companion> GetCompanionById(int companionId);
         Task<Companion> FindCompanionById(int companionId);
    }
}
