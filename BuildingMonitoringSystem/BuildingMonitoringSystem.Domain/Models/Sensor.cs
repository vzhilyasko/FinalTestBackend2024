namespace BuildingMonitoringSystem.Domain.Models
{
    public class Sensor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        //Тип датчика
        public string TypeSensor { get; set; }
        //Наименование датчика
        public string Name { get; set; }
        // Фото датчика
        public string PathPhoto { get; set; }
        //Описание датчика
        public string Description { get; set; }
        public decimal GeoCoordinateX { get; set; }
        public decimal GeoCoordinateY { get; set; }
        public decimal MaxIndications { get; set; }
        public decimal MinIndications { get; set; }
        public Guid IdBuilding { get; set; }
        public Building Building { get; set; }
        public Guid IdUser { get; set; }
        public User User { get; set; }
       
        public ICollection<IndicationsSensor> IndicationsSensors { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Sensor))
                return false;

            var sensor = (Sensor)obj;

            return sensor.Name == Name
                   && sensor.TypeSensor == TypeSensor
                   && sensor.Description == Description
                   && sensor.GeoCoordinateX == GeoCoordinateX
                   && sensor.GeoCoordinateY == GeoCoordinateY;
        }

        public static bool operator ==(Sensor first, Sensor second)
        {
            var equals = first.Equals(second);
            return equals;
        }

        public static bool operator !=(Sensor first, Sensor second)
        {
            var equals = !first.Equals(second);
            return equals;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name + TypeSensor + Description + GeoCoordinateX + GeoCoordinateY);
        }
    }
}
