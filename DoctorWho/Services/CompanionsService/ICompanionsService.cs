namespace DoctorWho.Services.CompanionsService
{
    public interface ICompanionsService
    {
        IEnumerable<string> GetCompanionsByEpisodeIdUsingFun(int id);
    }
}
