namespace DoctorWho.Db.Repository.EnemiesRepository
{
    public interface IEnemiesRepository
    {
        Task<IEnumerable<string>> GetAllEnemiesNameByEpisodeId(int id);
    }
}
