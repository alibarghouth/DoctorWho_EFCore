namespace DoctorWho.Services.EnemiesService
{
    public interface IEnemiesService
    {
        Task<string> GetAllEnemiesNameByEpisodeId(int episodeId);
    }
}
