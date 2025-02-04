using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Configurations;

public class PetConfigurations : IEntityTypeConfiguration<PetEntity>
{
    public void Configure(EntityTypeBuilder<PetEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
            .IsRequired();
        builder.Property(p => p.Age);
        builder.Property(p => p.Price);
    }
}