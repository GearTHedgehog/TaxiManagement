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

        public Task DeleteAsync(ICarId car)
        {
            return this.CarDataAccess.DeleteAsync(car);
        }
    }
}