namespace DoctorWho.Db.Repository.EnemiesRepository
{
    public interface IEnemiesRepository
    {
        IEnumerable<string> GetAllEnemiesNameByEpisodeId(int id);
    }
}
