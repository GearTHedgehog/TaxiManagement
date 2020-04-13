using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class DriverDeleteService:IDriverDeleteService
    {
        private IDriverDataAccess DriverDataAccess { get; }
        public DriverDeleteService(IDriverDataAccess driverDataAccess)
        {
            this.DriverDataAccess = driverDataAccess;
        }

        public Task DeleteAsync(IDriverId driver)
        {
           return this.DriverDataAccess.DeleteAsync(driver);
        }
    }
}