using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class DistrictConfiguration : IEntityTypeConfiguration<DistrictEntity>
    {
        public void Configure(EntityTypeBuilder<DistrictEntity> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.Doctors)
                .WithOne(d => d.DistrictEntity)
                .HasForeignKey(d => d.DistrictId);

            builder.HasMany(d => d.Patients)
                .WithOne(p => p.DistrictEntity)
                .HasForeignKey(p => p.DistrictId);
        }
    }
}
