using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Contracts
{
    public interface ICarGetService
    {
        Task<IEnumerable<Car>> GetAsync();
        Task<Car> GetAsync(ICarId car);
        Task ValidateAsync(ICarContainer car);
    }
}