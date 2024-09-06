using DataAccess.Configurations;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SRCDbContext : DbContext
    {
        public SRCDbContext(DbContextOptions<SRCDbContext> options)
            : base(options) { }

        public DbSet<CabinetEntity> Cabinets { get; set; }
        public DbSet<DistrictEntity> Districts { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<SpecificationEntity> Specifications { get; set; }
        public DbSet<AppointmentEntity> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CabinetConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new SpecificationConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
