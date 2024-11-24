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
    internal class IndicationsSensorConfiguration : IEntityTypeConfiguration<IndicationsSensor>
    {
        public void Configure(EntityTypeBuilder<IndicationsSensor> builder)
        {
            builder.ToTable("sensor");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(c => c.Indications)
                .HasColumnType("decimal")
                .HasColumnName("indications")
                .IsRequired();

            builder.Property(c => c.InsertDate)
                .HasColumnType("date")
                .HasColumnName("insert_date")
                .IsRequired();
            
            builder.HasOne(x => x.Sensor)
                .WithMany(x => x.IndicationsSensors)
                .HasForeignKey(x => x.IdSensor)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(e => e.Id);
        }
    }
}
