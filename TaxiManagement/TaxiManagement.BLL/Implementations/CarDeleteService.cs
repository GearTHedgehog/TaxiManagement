using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class CarDeleteService:ICarDeleteService
    {
        private ICarDataAccess CarDataAccess { get; }
            public CarDeleteService(ICarDataAccess carDataAccess)
        {
            this.CarDataAccess = carDataAccess;
        }

        public async Task DeleteAsync(ICarId car)
        {
            //await this.DepotGetService.ValidateAsync(car); //проверка, привязана ли машина к депо
            await this.CarDataAccess.DeleteAsync(car);
        }
    }
}