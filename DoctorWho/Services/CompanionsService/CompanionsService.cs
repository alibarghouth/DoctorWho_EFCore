using DoctorWho.Db.Repository.CompanionsRepository;

namespace DoctorWho.Services.CompanionsService
{
    public class CompanionsService : ICompanionsService
    {
        private readonly ICompanionsRepository _companionsRepository;

        public CompanionsService(ICompanionsRepository companionsRepository)
        {
            _companionsRepository = companionsRepository;
        }

        public async Task<IEnumerable<string>> GetCompanionsByEpisodeIdUsingFun(int id)
        {
            return await _companionsRepository.GetCompanionsByEpisodeIdUsingFun(id);
        }
    }
}
