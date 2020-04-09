using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Contracts
{
    public interface ICarCreateService
    {
        Task<Car> CreateAsync(CarUpdateModel car);
    }
}