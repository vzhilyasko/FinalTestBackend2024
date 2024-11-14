using BuildingMonitoringSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingMonitoringSystem.Data.EntityConfigurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("building");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(c => c.InsertDate)
                .HasColumnType("date")
                .HasColumnName("insertdate")
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar")
                .HasColumnName("description")
                .IsRequired();

            builder.Property(a => a.IdSensor)
                .HasColumnName("id_sensor")
                .HasColumnType("uuid");
            
            builder.HasOne(x => x.Sensor)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.IdSensor)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(e => e.Id);
        }
    }
}
