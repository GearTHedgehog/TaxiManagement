using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Contracts
{
    public interface ICarDeleteService
    {
        Task DeleteAsync(ICarId car);
    }
}