using BuildingMonitoringSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingMonitoringSystem.Data.EntityConfigurations
{
    internal class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("building");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(c => c.Name)
                .HasColumnType("varchar")
                .HasColumnName("name")
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar")
                .HasColumnName("description")
                .IsRequired();

            builder.Property(a => a.Address)
                .HasColumnName("address")
                .HasColumnType("varchar");

            builder.Property(a => a.GeoCoordinateX)
                .HasColumnType("decimal")
                .HasColumnName("geo_coordinate_x");

            builder.Property(a => a.GeoCoordinateY)
                .HasColumnType("decimal")
                .HasColumnName("geo_coordinate_y");

            builder.Property(a => a.IdUser)
                .HasColumnType("uuid")
                .HasColumnName("id_user");

            builder.HasOne(x => x.User)
               .WithMany(x => x.Buildings)
               .HasForeignKey(x => x.IdUser)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(e => e.Id);
        }
    }
}
