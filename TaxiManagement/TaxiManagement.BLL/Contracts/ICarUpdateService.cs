using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Contracts
{
    public interface ICarUpdateService
    {
        Task<Car> UpdateAsync(CarUpdateModel car);
    }
}