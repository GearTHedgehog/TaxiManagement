using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class CarUpdateService:ICarUpdateService
    {
        private IDepotGetService DepotGetService { get; }

        public CarUpdateService(IDepotGetService depotGetService)
        {
            this.DepotGetService = depotGetService;
        }

        public async Task<Car> UpdateAsync(CarUpdateModel car)
        {
            await this.DepotGetService.ValidateAsync(car);
            throw new System.NotImplementedException();
        }
    }
}