using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.CompanionsRepository;
using DoctorWho.Exceptions;

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

        public async Task<CompanionRequestModel> AddCompanionAsync(CompanionRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.WhoPlayed))
                throw new DoctorWhoException();

            var companion = _mapper.Map<Companion>(request);
            var result = _mapper.Map<CompanionRequestModel>(await _companionsRepository.AddCompanionAsync(companion));

            return result is null ? throw new NullReferenceException() : result;
        }

        public async Task<bool> DeleteCompanionAsync(int companionId)
        {
            if (companionId == 0)
                return false;
            var result = await _companionsRepository.DeleteCompanionAsync(companionId);
            if (!result)
                return false;
            return false;
        }

        public async Task<CompanionRequestModel> UpdateCompanionAsync(CompanionRequestModel request, int companionId)
        {
            if (companionId == 0)
                throw new DoctorWhoException();

            var companion = await _companionsRepository.FindCompanionById(companionId);

            if (!string.IsNullOrEmpty(request.Name))
                companion.Name = request.Name;
            if (!string.IsNullOrEmpty(request.WhoPlayed))
                companion.WhoPlayed = request.WhoPlayed;
            var result = _mapper.Map<CompanionRequestModel>(await _companionsRepository.UpdateCompanionAsync(companion));

            return result is null ? throw new NullReferenceException() : result;
        }

        public async Task<Companion?> GetCompanionById(int companionId)
        {
            return await _companionsRepository.GetCompanionById(companionId);
        }
    }
}
