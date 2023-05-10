namespace DoctorWho.Db.Model
{
    public class EpisodesView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string? DoctorName { get; set; }
        public string? Companions { get; set; }
        public string? Enemies { get; set; }
    }
}
