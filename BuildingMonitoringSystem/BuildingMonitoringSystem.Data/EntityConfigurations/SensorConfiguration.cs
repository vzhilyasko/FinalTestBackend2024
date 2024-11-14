using BuildingMonitoringSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMonitoringSystem.Data.EntityConfigurations
{
    internal class SensorConfiguration : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.ToTable("sensor");

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

            builder.Property(c => c.PathPhoto)
                .HasColumnType("varchar")
                .HasColumnName("path_photo")
                .IsRequired();

            builder.Property(a => a.TypeSensor)
                .HasColumnName("type_sensor")
                .HasColumnType("varchar");

            builder.Property(a => a.MaxIndications)
                .HasColumnType("decimal")
                .HasColumnName("max_indications");

            builder.Property(a => a.MinIndications)
                .HasColumnType("decimal")
                .HasColumnName("minindications");

            builder.Property(a => a.GeoCoordinateX)
                .HasColumnType("decimal")
                .HasColumnName("geo_coordinate_x");

            builder.Property(a => a.GeoCoordinateY)
                .HasColumnType("decimal")
                .HasColumnName("geo_coordinate_y");

            builder.Property(a => a.IdUser)
                .HasColumnType("uuid")
                .HasColumnName("id_user");

            builder.Property(a => a.IdBuilding)
                .HasColumnType("uuid")
                .HasColumnName("id_building");
            
            builder.HasOne(x => x.Building)
                .WithMany(x => x.Sensors)
                .HasForeignKey(x => x.IdBuilding)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Sensors)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(e => e.Id);
        }
    }
}
