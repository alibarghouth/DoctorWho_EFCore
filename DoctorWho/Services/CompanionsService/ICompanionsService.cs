namespace DoctorWho.Services.CompanionsService
{
    public interface ICompanionsService
    {
        Task<IEnumerable<string>> GetCompanionsByEpisodeIdUsingFun(int id);
    }
}
