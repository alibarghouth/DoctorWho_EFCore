namespace DoctorWho.Db.Repository.EnemiesRepository
{
    public interface IEnemiesRepository
    {
        Task<string> GetAllEnemiesNameByEpisodeId(int episodeId);
    }
}
