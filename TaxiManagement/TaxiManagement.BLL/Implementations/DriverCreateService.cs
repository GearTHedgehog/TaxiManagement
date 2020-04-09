using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class DriverCreateService:IDriverCreateService
    {
        private ICarGetService CarGetService { get; }

        public DriverCreateService(ICarGetService carGetService)
        {
            this.CarGetService = carGetService;
        }

        public async Task<Driver> CreateAsync(DriverUpdateModel driver)
        {
            await this.CarGetService.ValidateAsync(driver);
            throw new System.NotImplementedException();
        }
    }
}