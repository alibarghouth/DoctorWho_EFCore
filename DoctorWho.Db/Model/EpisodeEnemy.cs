using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Db.Model
{
    public class EpisodeEnemy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EnemyId { get; set; }
        public int EpisodeId { get; set; }
        public Enemy Enemy { get; set; } = default!;
        public Episode Episode { get; set; } = default!;
    }
}
