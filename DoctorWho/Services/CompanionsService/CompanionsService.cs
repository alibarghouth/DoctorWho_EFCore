using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.CompanionsRepository;

namespace DoctorWho.Services.CompanionsService
{
    public class CompanionsService : ICompanionsService
    {
        private readonly ICompanionsRepository _companionsRepository;

        public CompanionsService(ICompanionsRepository companionsRepository)
        {
            _companionsRepository = companionsRepository;
        }

        public async Task<string> GetCompanionsByEpisodeId(int episodeId)
        {
            return await _companionsRepository.GetCompanionsByEpisodeId(episodeId);
        }

        public async Task<string> AddCompanionAsync(CompanionRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.WhoPlayed))
                return "all input is required";
            var companion = await _companionsRepository.AddCompanionAsync(request);
            
            if (companion is null)
                return "failed";
            return "success";
        }

        public async Task<string> DeleteCompanionAsync(int companionId)
        {
            if (companionId == 0)
                return "failed";
            var result = await _companionsRepository.DeleteCompanionAsync(companionId);
            if (!result)
                return "failed";
            return "success";
        }

        public async Task<string> UpdateCompanionAsync(CompanionRequestModel request, int companionId)
        {
            if (companionId == 0)
                return "failed";
            var result = await _companionsRepository.UpdateCompanionAsync(request, companionId);
            if (!result)
                return "failed";
            return "success";
        }

        public async Task<Companion?> GetCompanionById(int companionId)
        {
            return await _companionsRepository.GetCompanionById(companionId);
        }
    }
}
