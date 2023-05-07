using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Db.Model
{
    public class Companion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string WhoPlayed { get; set; }
        public List<EpisodeCompanion> EpisodeCompanions { get; set; } = default!;
    }
}
