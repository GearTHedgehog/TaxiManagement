using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

//every return null is temporary
namespace TaxiManagement.BLL.Implementations
{
    public class CarCreateService:ICarCreateService
    {
        private IDepotGetService DepotGetService { get; }

        public CarCreateService(IDepotGetService depotGetService)
        {
            this.DepotGetService = depotGetService;
        }

        public async Task<Car> CreateAsync(CarUpdateModel car)
        {
            await this.DepotGetService.ValidateAsync(car);
            throw new System.NotImplementedException();
        }
    }
}