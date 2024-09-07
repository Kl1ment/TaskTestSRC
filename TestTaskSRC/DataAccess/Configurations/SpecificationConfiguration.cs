using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class SpecificationConfiguration : IEntityTypeConfiguration<SpecificationEntity>
    {
        public void Configure(EntityTypeBuilder<SpecificationEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Doctors)
                .WithOne(d => d.SpecificationEntity)
                .HasForeignKey(d => d.SpecificationId);
        }
    }
}
