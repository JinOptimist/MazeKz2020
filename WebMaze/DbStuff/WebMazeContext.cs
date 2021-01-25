using Microsoft.EntityFrameworkCore;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Medicine;
using WebMaze.DbStuff.Model.Police;
using WebMaze.DbStuff.Model.UserAccount;

namespace WebMaze.DbStuff
{
    public class WebMazeContext : DbContext
    {
        public DbSet<CitizenUser> CitizenUser { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Adress> Adress { get; set; }

        public DbSet<Policeman> Policemen { get; set; }

        public DbSet<Violation> Violations { get; set; }

        public DbSet<PoliceCertificate> PoliceCertificates { get; set; }

        public DbSet<HealthDepartment> HealthDepartment { get; set; }
        public DbSet<RecordForm> RecordForms { get; set; }

        public DbSet<Bus> Bus { get; set; }

        public DbSet<BusStop> BusStop { get; set; }

        public DbSet<BusRoute> BusRoute { get; set; }

        public DbSet<BusOrder> BusOrder { get; set; }

        public DbSet<BusWorker> BusWorker { get; set; }

        public DbSet<BusRouteTime> BusRouteTime { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<MedicalInsurance> MedicalInsurances { get; set; }
        public DbSet<MedicineCertificate> MedicineCertificates { get; set; }

        public WebMazeContext(DbContextOptions dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitizenUser>()
                .HasMany(citizen => citizen.Adresses)
                .WithOne(adress => adress.Owner);

            modelBuilder
                .Entity<CitizenUser>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.ToTable("CitizenUserRoles"));

            modelBuilder.Entity<CitizenUser>()
                .HasOne(c => c.MedicalInsurance)
                .WithOne(m => m.Owner);

            modelBuilder.Entity<CitizenUser>()
                .HasMany(citizen => citizen.RecordForms)
                .WithOne(records => records.CitizenId);

            modelBuilder.Entity<CitizenUser>()
                .HasOne(p => p.MedicineCertificate)
                .WithOne(o => o.User);

            modelBuilder.Entity<CitizenUser>()
                .HasMany(citizen => citizen.Certificates)
                .WithOne(certificate => certificate.Owner);

            base.OnModelCreating(modelBuilder);
        }
    }
}
