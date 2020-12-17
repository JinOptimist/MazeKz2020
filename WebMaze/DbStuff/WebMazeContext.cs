using Microsoft.EntityFrameworkCore;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Police;

namespace WebMaze.DbStuff
{
    public class WebMazeContext : DbContext
    {
        public DbSet<CitizenUser> CitizenUser { get; set; }

        public DbSet<Adress> Adress { get; set; }

        public DbSet<Policeman> Policemen { get; set; }

        public DbSet<Violation> Violations { get; set; }
        
        public DbSet<ViolationType> TypesOfViolation { get; set; }

        public DbSet<HealthDepartment> HealthDepartment { get; set; }

        public DbSet<Bus> Bus { get; set; }

        public DbSet<BusStop> BusStop { get; set; }

        public DbSet<BusRoute> BusRoute { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        public WebMazeContext(DbContextOptions dbContext) : base(dbContext) { }
    }
}
