namespace BuildingMonitoringSystem.Domain.Models
{
    public class Notification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime InsertDate { get; set; }
        public Guid IdSensor { get; set; }
        public string Description { get; set; }
        public Sensor Sensor { get; set; }
    }
}
