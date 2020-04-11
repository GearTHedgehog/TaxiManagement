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

        public async Task DeleteAsync(IDriverId driver)
        {
            //await this.DepotGetService.ValidateAsync(car); //проверка, привязана ли машина к депо
            await this.DriverDataAccess.DeleteAsync(driver);
        }
    }
}