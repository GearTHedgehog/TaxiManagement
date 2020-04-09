using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class CarUpdateService:ICarUpdateService
    {
        private IDepotGetService DepotGetService { get; } //каждая машина привязывается к депо, нужно проверить, существует ли депо

        public CarUpdateService(IDepotGetService depotGetService)
        {
            this.DepotGetService = depotGetService;
        }

        public async Task<Car> UpdateAsync(CarUpdateModel car)
        {
            await this.DepotGetService.ValidateAsync(car);//проверка, привязана ли машина к депо
            throw new System.NotImplementedException();
        }
    }
}