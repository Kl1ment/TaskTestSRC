using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class CabinetConfiguration : IEntityTypeConfiguration<CabinetEntity>
    {
        public void Configure(EntityTypeBuilder<CabinetEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Doctors)
                .WithOne(d => d.CabinetEntity)
                .HasPrincipalKey(c => c.Number)
                .HasForeignKey(d => d.Cabinet);
        }
    }
}
