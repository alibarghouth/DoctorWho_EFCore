using DoctorWho.Db.Context;
using DoctorWho.Db.Model;

namespace DoctorWho
{
    public class Program
    {
        private static void Main(string[] args)
        {
           var context = new DoctorWhoCoreDbContext();
            context.Enemies.Add(new Enemy { Description = "ali",Name = "er"});
            context.SaveChanges();
        }
    }
}