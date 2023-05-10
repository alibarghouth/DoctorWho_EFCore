using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.ModelCreating
{
    public static class Creations
    {
        public static void CreationModel(this ModelBuilder modelBuilder)
        {
            AddPrimaryKey(modelBuilder);
            SeedingData(modelBuilder);
        }
        private static void AddPrimaryKey(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enemy>()
              .HasKey(e => e.Id);
            modelBuilder.Entity<Author>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Companion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Episode>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Enemy>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<EpisodeEnemy>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<EpisodeCompanion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<EpisodesView>()
                .ToView("viewEpisodes")
                .HasNoKey();
        }
        private static void SeedingData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enemy>()
                .HasData
                (
                new Enemy { Id = 1, Description = "Description1", Name = "Name1" },
                new Enemy { Id = 2, Description = "Description2", Name = "Name2" },
                new Enemy { Id = 3, Description = "Description3", Name = "Name3" },
                new Enemy { Id = 4, Description = "Description4", Name = "Name4" },
                new Enemy { Id = 5, Description = "Description5", Name = "Name5" }
                );
            modelBuilder.Entity<Companion>()
                .HasData
                (
                new Companion { Id = 1, Name = "Companion1", WhoPlayed = "WhoPlayed1", },
                new Companion { Id = 2, Name = "Companion2", WhoPlayed = "WhoPlayed2", },
                new Companion { Id = 3, Name = "Companion3", WhoPlayed = "WhoPlayed3", },
                new Companion { Id = 4, Name = "Companion4", WhoPlayed = "WhoPlayed4", },
                new Companion { Id = 5, Name = "Companion5", WhoPlayed = "WhoPlayed5", }
                );
            modelBuilder.Entity<Doctor>()
                .HasData
                (
                new Doctor { Id = 1, BirthDate = new DateTime(1999, 2, 3), LastEpisodeDate = new DateTime(2000, 3, 4), Name = "Doctor", Number = "0599728416", FirstEpisodeDate = new DateTime(2000, 4, 5) },
                new Doctor { Id = 2, BirthDate = new DateTime(1999, 2, 3), LastEpisodeDate = new DateTime(2000, 3, 4), Name = "Doctor2", Number = "0599728416", FirstEpisodeDate = new DateTime(2000, 4, 5) },
                new Doctor { Id = 3, BirthDate = new DateTime(1999, 2, 3), LastEpisodeDate = new DateTime(2000, 3, 4), Name = "Doctor3", Number = "0599728416", FirstEpisodeDate = new DateTime(2000, 4, 5) },
                new Doctor { Id = 4, BirthDate = new DateTime(1999, 2, 3), LastEpisodeDate = new DateTime(2000, 3, 4), Name = "Doctor4", Number = "0599728416", FirstEpisodeDate = new DateTime(2000, 4, 5) },
                new Doctor { Id = 5, BirthDate = new DateTime(1999, 2, 3), LastEpisodeDate = new DateTime(2000, 3, 4), Name = "Doctor5", Number = "0599728416", FirstEpisodeDate = new DateTime(2000, 4, 5) }
                );
            modelBuilder.Entity<Author>()
                .HasData
                (
                new Author { Id = 1, Name = "Auther1" },
                new Author { Id = 2, Name = "Auther2" },
                new Author { Id = 3, Name = "Auther3" },
                new Author { Id = 4, Name = "Auther4" },
                new Author { Id = 5, Name = "Auther5" }
                );
            modelBuilder.Entity<Episode>()
                .HasData
                (
                new Episode { Id = 1, AuthorId = 2, DoctorId = 2, SeriesNumber = 123, EpisodeNumber = 234, Episodetype = "type1", Notes = "notes1", Title = "title1", EpsodeDate = new DateTime(2000, 3, 4) },
                new Episode { Id = 2, AuthorId = 1, DoctorId = 3, SeriesNumber = 123, EpisodeNumber = 234, Episodetype = "type1", Notes = "notes1", Title = "title1", EpsodeDate = new DateTime(2000, 3, 4) },
                new Episode { Id = 3, AuthorId = 4, DoctorId = 4, SeriesNumber = 123, EpisodeNumber = 234, Episodetype = "type1", Notes = "notes1", Title = "title1", EpsodeDate = new DateTime(2000, 3, 4) },
                new Episode { Id = 4, AuthorId = 3, DoctorId = 5, SeriesNumber = 123, EpisodeNumber = 234, Episodetype = "type1", Notes = "notes1", Title = "title1", EpsodeDate = new DateTime(2000, 3, 4) },
                new Episode { Id = 5, AuthorId = 5, DoctorId = 2, SeriesNumber = 123, EpisodeNumber = 234, Episodetype = "type1", Notes = "notes1", Title = "title1", EpsodeDate = new DateTime(2000, 3, 4) }
                );
            modelBuilder.Entity<EpisodeEnemy>()
                .HasData
                (
                new EpisodeEnemy { Id = 1, EnemyId = 2, EpisodeId = 3 },
                new EpisodeEnemy { Id = 2, EnemyId = 1, EpisodeId = 4 },
                new EpisodeEnemy { Id = 3, EnemyId = 4, EpisodeId = 3 },
                new EpisodeEnemy { Id = 4, EnemyId = 5, EpisodeId = 2 },
                new EpisodeEnemy { Id = 5, EnemyId = 5, EpisodeId = 2 }
                );
            modelBuilder.Entity<EpisodeCompanion>()
                .HasData
                (
                new EpisodeCompanion { Id = 1, EpisodeId = 1, CompanionId = 5 },
                new EpisodeCompanion { Id = 2, EpisodeId = 4, CompanionId = 2 },
                new EpisodeCompanion { Id = 3, EpisodeId = 5, CompanionId = 4 },
                new EpisodeCompanion { Id = 4, EpisodeId = 2, CompanionId = 2 },
                new EpisodeCompanion { Id = 5, EpisodeId = 1, CompanionId = 1 }
                );
        }
    }
}
