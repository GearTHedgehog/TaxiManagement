using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class DriverUpdateService:IDriverUpdateService
    {
        private IDriverDataAccess DriverDataAccess { get; }
        private ICarGetService CarGetService { get; } //каждый водитель привязывается к машине, нужно проверить, существует ли машина

       public DriverUpdateService(ICarGetService carGetService, IDriverDataAccess driverDataAccess)
       {
           this.DriverDataAccess = driverDataAccess;
           this.CarGetService = carGetService;
       }

       public async Task<Driver> UpdateAsync(DriverUpdateModel driver)
       {
           await this.CarGetService.ValidateAsync(driver); //проверка, привязан ли водитель к машине
           return await this.DriverDataAccess.UpdateAsync(driver);
       }
    }
}