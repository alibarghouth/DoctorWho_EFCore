using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.CompanionsRepository;

namespace DoctorWho.Services.CompanionsService
{
    public class CompanionsService : ICompanionsService
    {
        private readonly ICompanionsRepository _companionsRepository;
        private readonly IMapper _mapper;

        public CompanionsService(ICompanionsRepository companionsRepository, IMapper mapper)
        {
            _companionsRepository = companionsRepository;
            _mapper = mapper;
        }

        public async Task<string> GetCompanionsByEpisodeId(int episodeId)
        {
            return await _companionsRepository.GetCompanionsByEpisodeId(episodeId);
        }

        public async Task<string> AddCompanionAsync(CompanionRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.WhoPlayed))
                return "all input is required";
            var companion = _mapper.Map<Companion>(request);
            var result = await _companionsRepository.AddCompanionAsync(companion);
            if (result is null)
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
            
            var companion = await _companionsRepository.FindCompanionById(companionId);
            
            if (!string.IsNullOrEmpty(request.Name))
                companion.Name = request.Name;
            if (!string.IsNullOrEmpty(request.WhoPlayed))
                companion.WhoPlayed = request.WhoPlayed;
            var result = await _companionsRepository.UpdateCompanionAsync(companion);
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
