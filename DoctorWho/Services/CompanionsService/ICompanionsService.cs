using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Services.CompanionsService
{
    public interface ICompanionsService
    {
        Task<string> GetCompanionsByEpisodeId(int episodeId);
        Task<string> AddCompanionAsync(CompanionRequestModel request);
        Task<string> DeleteCompanionAsync(int companionId);
        Task<string> UpdateCompanionAsync(CompanionRequestModel request, int companionId);
    }
}
