using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Services.CompanionsService
{
    public interface ICompanionsService
    {
        Task<string> GetCompanionsByEpisodeId(int episodeId);
        Task<CompanionRequestModel> AddCompanionAsync(CompanionRequestModel request);
        Task<bool> DeleteCompanionAsync(int companionId);
        Task<CompanionRequestModel> UpdateCompanionAsync(CompanionRequestModel request, int companionId);
        Task<Companion?> GetCompanionById(int companionId);
    }
}
