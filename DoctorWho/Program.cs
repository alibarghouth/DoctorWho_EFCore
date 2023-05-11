using DoctorWho.Db.Repositories.DoctorRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorWho
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IServiceCollection c = new ServiceCollection();
            c.AddAutoMapper(typeof(Program));
            c.AddScoped<IDoctorRepository, DoctorRepository>();
        }
    }
}