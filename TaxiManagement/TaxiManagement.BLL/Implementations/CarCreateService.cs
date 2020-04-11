using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

//every return null is temporary
namespace TaxiManagement.BLL.Implementations
{
    public class CarCreateService:ICarCreateService
    {
        private ICarDataAccess CarDataAccess { get; }
        private IDepotGetService DepotGetService { get; } //каждая машина привязывается к депо, нужно проверить, существует ли депо

        public CarCreateService(IDepotGetService depotGetService, ICarDataAccess carDataAccess)
        {
            this.CarDataAccess = carDataAccess;
            this.DepotGetService = depotGetService;
        }

        public async Task<Car> CreateAsync(CarUpdateModel car)
        {
            await this.DepotGetService.ValidateAsync(car); //проверка, привязана ли машина к депо
            return await this.CarDataAccess.InsertAsync(car);
        }
    }
}