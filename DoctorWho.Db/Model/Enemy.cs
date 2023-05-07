using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Db.Model
{
    public class Enemy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EpisodeEnemy> EpisodeEnemies { get; set; } = default!;
    }
}
