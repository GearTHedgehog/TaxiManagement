using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class DriverUpdateService:IDriverUpdateService
    {
       private ICarGetService CarGetService { get; }

       public DriverUpdateService(ICarGetService carGetService)
       {
           this.CarGetService = carGetService;
       }

       public async Task<Driver> UpdateAsync(DriverUpdateModel driver)
       {
           await this.CarGetService.ValidateAsync(driver);
           throw new System.NotImplementedException();
       }
    }
}