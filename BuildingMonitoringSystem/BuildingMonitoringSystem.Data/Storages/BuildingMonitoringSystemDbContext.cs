using BuildingMonitoringSystem.Data.EntityConfigurations;
using BuildingMonitoringSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingMonitoringSystem.Data.Storages
{
    internal class BuildingMonitoringSystemDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Sensor> Sensors => Set<Sensor>();
        public DbSet<IndicationsSensor> IndicationsSensors => Set<IndicationsSensor>();
        public DbSet<Notification> Notifications => Set<Notification>();
        static BuildingMonitoringSystemDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={BuildingMonitoringSystem.Data.Resource1.ConnectionStringHost};" +
                                     $"Port = {BuildingMonitoringSystem.Data.Resource1.ConnectionStringPort};" +
                                     $"Database = {BuildingMonitoringSystem.Data.Resource1.ConnectionStringDatabase};" +
                                     $"Username = {BuildingMonitoringSystem.Data.Resource1.ConnectionStringUsername};" +
                                     $"Password = {BuildingMonitoringSystem.Data.Resource1.ConnectionStringPassword}");
        }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new
                ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new SensorConfiguration());
            modelBuilder.ApplyConfiguration(new IndicationsSensorConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
