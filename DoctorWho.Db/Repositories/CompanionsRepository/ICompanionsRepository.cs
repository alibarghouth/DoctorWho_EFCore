using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repository.CompanionsRepository
{
    public interface ICompanionsRepository
    {
        IEnumerable<string> GetCompanionsByEpisodeIdUsingFun(int id);
    }
}
