using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMonitoringSystem.Domain.Models
{
    public class IndicationsSensor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdSensor { get; set; }
        public DateTime InsertDate { get; set; }
        public decimal Indications { get; set; }
        public Sensor Sensor { get; set; }
    }
}
