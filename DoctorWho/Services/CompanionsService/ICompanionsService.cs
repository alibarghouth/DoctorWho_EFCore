namespace DoctorWho.Services.CompanionsService
{
    public interface ICompanionsService
    {
        Task<string> GetCompanionsByEpisodeId(int episodeId);
    }
}
