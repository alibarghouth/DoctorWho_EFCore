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

        public IEnumerable<string> GetCompanionsByEpisodeIdUsingFun(int id)
        {
            return _companionsRepository.GetCompanionsByEpisodeIdUsingFun(id);
        }
    }
}
