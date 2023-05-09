namespace DoctorWho.Services.EnemiesService
{
    public interface IEnemiesService
    {
        Task<IEnumerable<string>> GetAllEnemiesNameByEpisodeId(int id);
    }
}
