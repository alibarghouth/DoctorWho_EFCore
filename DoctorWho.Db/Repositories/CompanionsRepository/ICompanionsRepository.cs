using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repository.CompanionsRepository
{
    public interface ICompanionsRepository
    {
        Task<IEnumerable<string>> GetCompanionsByEpisodeIdUsingFun(int id);
    }
}
