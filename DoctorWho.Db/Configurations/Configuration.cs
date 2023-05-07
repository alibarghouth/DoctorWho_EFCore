using DoctorWho.Db.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DoctorWho.Db.Configurations
{
    public static class Configuration
    {
        public static void AddDoctorWhoConfiguration(this DbContextOptionsBuilder optionsBuilder)
        {
            AddDatabase(optionsBuilder);
        }
        private static void AddDatabase(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(@"C:\Users\user\source\repos\DoctorWho\DoctorWho.Db")
                   .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            var connectionString = config.GetSection("ConnectionStrings").Get<ConnectionStrings>();
            optionsBuilder.UseSqlServer(connectionString.DefaultConnection);
        }
    }
}
