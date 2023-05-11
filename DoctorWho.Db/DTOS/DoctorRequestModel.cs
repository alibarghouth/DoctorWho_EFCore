namespace DoctorWho.Db.DTOS;

public class DoctorRequestModel
{
         public string? Name { get; set; }
         public string? Number { get; set; }
         public DateTime BirthDate { get; set; }
         public DateTime FirstEpisodeDate { get; set; }
         public DateTime LastEpisodeDate { get; set; }   
}