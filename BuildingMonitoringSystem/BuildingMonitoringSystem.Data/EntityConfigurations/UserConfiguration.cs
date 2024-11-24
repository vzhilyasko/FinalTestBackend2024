using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BuildingMonitoringSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingMonitoringSystem.Data.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(c => c.Login)
                .HasColumnType("varchar")
                .HasColumnName("login")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(c => c.Password)
                .HasColumnType("varchar")
                .HasColumnName("password")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(a => a.FIO)
                .HasColumnName("fio")
                .HasColumnType("varchar");

            builder.Property(a => a.Email)
                .HasColumnType("varchar")
                .HasColumnName("e_mail");

            builder.HasKey(e => e.Id);
        }
    }
}
