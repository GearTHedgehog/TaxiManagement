using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class CarUpdateService:ICarUpdateService
    {
        private ICarDataAccess CarDataAccess { get; }
        private IDepotGetService DepotGetService { get; } //каждая машина привязывается к депо, нужно проверить, существует ли депо

        public CarUpdateService(IDepotGetService depotGetService, ICarDataAccess carDataAccess)
        {
            this.CarDataAccess = carDataAccess;
            this.DepotGetService = depotGetService;
        }

        public async Task<Car> UpdateAsync(CarUpdateModel car)
        {
            await this.DepotGetService.ValidateAsync(car);//проверка, привязана ли машина к депо
            return await this.CarDataAccess.UpdateAsync(car);
        }
    }
}