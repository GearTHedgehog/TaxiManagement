using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.DataAccess.Implementations;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class CarGetService:ICarGetService
    {
        private ICarDataAccess CarDataAccess { get; set; }

        public CarGetService(ICarDataAccess carDataAccess)
        {
            this.CarDataAccess = carDataAccess;
        }
        public Task<Car> GetAsync(ICarId car)
        {
            return this.CarDataAccess.GetAsync(car);
        }

        public Task<IEnumerable<Car>> GetAsync()
        {
            return this.CarDataAccess.GetAsync();
        }

        private Task<Car> GetBy(ICarContainer carContainer)
        {
            return this.CarDataAccess.GetByAsync(carContainer);
        }

        public async Task ValidateAsync(ICarContainer carContainer)
        {
            if (carContainer == null)
            {
                throw new ArgumentNullException(nameof(carContainer));
            }

            var car = await this.GetBy(carContainer);
            if (carContainer.CarId.HasValue && car == null)
            {
                throw new InvalidOperationException($"Car not found by id {carContainer.CarId}");
            }
        }
    }
}