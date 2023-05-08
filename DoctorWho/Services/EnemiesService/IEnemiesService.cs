namespace DoctorWho.Services.EnemiesService
{
    public interface IEnemiesService
    {
        IEnumerable<string> GetAllEnemiesNameByEpisodeId(int id);
    }
}
