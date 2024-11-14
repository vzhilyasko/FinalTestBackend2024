using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingMonitoringSystem.Domain.Models;

namespace BuildingMonitoringSystem.App.Interfaces
{
    internal interface ISensorStorage: IStorage<Sensor, Dictionary<Sensor, List<IndicationsSensor>>>
    {
        public Task AddIndicationsSensorAsync(Sensor sensor, IndicationsSensor indicationsSensor);
        public Task UpdateIndicationsSensorAsync(Sensor sensor, IndicationsSensor indicationsSensor);
        public Task DeleteIndicationsSensorAsync(Sensor sensor, IndicationsSensor indicationsSensor);
    }
}
