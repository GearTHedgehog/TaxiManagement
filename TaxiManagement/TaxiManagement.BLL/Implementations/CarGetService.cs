using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class CarGetService:ICarGetService
    {
        public Task<Car> GetAsync(ICarId car)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task ValidateAsync(ICarContainer car)
        {
            throw new System.NotImplementedException();
        }
    }
}