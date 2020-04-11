using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.DataAccess.Contracts
{
    public interface ICarDataAccess
    {
        Task<Car> InsertAsync(CarUpdateModel car);
        Task<IEnumerable<Car>> GetAsync();
        Task<Car> GetByAsync(ICarContainer carId);
        Task<Car> GetAsync(ICarId carId);
        Task<Car> UpdateAsync(CarUpdateModel car);
        Task DeleteAsync(ICarId car);
    }
}