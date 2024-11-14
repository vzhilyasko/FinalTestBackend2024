using BuildingMonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMonitoringSystem.App.Interfaces
{
    internal interface IUserStorage: IStorage<User, Dictionary<User, List<Building>>>
    {
        public Task AddBuildingAsync(User user, Building building);
        public Task UpdateBuildingAsync(User user, Building building);
        public Task DeleteBuildingAsync(User user, Building building);
    }
}
