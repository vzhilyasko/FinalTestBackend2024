using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;


namespace BuildingMonitoringSystem.Domain.Models
{
    public class Building
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        //Наименование здания
        public string Name { get; set; }
        public string Address { get;set; }
        //Описание здания
        public string Description { get; set; }
        public decimal GeoCoordinateX { get; set; }
        public decimal GeoCoordinateY { get; set; }
        public Guid IdUser { get; set;}
        public User User { get; set; }

        public ICollection<Sensor> Sensors { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Building))
                return false;

            var building = (Building)obj;

            return building.Name == Name
           && building.Address == Address
           && building.GeoCoordinateX == GeoCoordinateX
           && building.GeoCoordinateY == GeoCoordinateY;
        }

        public static bool operator ==(Building first, Building second)
        {
            var equals = first.Equals(second);
            return equals;
        }

        public static bool operator !=(Building first, Building second)
        {
            var equals = !first.Equals(second);
            return equals;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name + Address + GeoCoordinateX + GeoCoordinateY);
        }
    }
}
