using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Db.Model
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Episode> Episodes { get; set; } = default!;
    }
}
