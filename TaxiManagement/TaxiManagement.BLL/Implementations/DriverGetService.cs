using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.DataAccess.Implementations;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class DriverGetService:IDriverGetService
    {
        private IDriverDataAccess DriverDataAccess { get; set; }

        public DriverGetService(IDriverDataAccess driverDataAccess)
        {
            this.DriverDataAccess = driverDataAccess;
        }
        public Task<IEnumerable<Driver>> GetAsync()
        {
            return this.DriverDataAccess.GetAsync();
        }

        public Task<Driver> GetAsync(IDriverId driver)
        {
            return this.DriverDataAccess.GetAsync(driver);
        }
    }
}