namespace DoctorWho.Db.Model
{
    public class EpisodeCompanion
    {
        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public int CompanionId { get; set; }
        public Episode Episode { get; set; } = default!;
        public Companion Companion { get; set; } = default!;
    }
}
