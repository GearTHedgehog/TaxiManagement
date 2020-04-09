using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

//every return null is temporary
namespace TaxiManagement.BLL.Implementations
{
    public class CarCreateService:ICarCreateService
    {
        private IDepotGetService DepotGetService { get; } //каждая машина привязывается к депо, нужно проверить, существует ли депо

        public CarCreateService(IDepotGetService depotGetService)
        {
            this.DepotGetService = depotGetService;
        }

        public async Task<Car> CreateAsync(CarUpdateModel car)
        {
            await this.DepotGetService.ValidateAsync(car); //проверка, привязана ли машина к депо
            throw new System.NotImplementedException();
        }
    }
}