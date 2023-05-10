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
    }
}
