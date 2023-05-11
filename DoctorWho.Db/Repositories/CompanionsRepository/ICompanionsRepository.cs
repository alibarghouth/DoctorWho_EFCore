using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.CompanionsRepository
{
    public interface ICompanionsRepository
    {
         Task<string> GetCompanionsByEpisodeId(int episodeId);
         Task<Companion?> AddCompanionAsync(CompanionRequestModel request);
         Task<bool> DeleteCompanionAsync(int companionId);
         Task<bool> UpdateCompanionAsync(CompanionRequestModel request, int companionId);
         Task<Companion?> GetCompanionById(int companionId);
    }
}
