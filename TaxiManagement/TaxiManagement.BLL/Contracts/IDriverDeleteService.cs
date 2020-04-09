using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Contracts
{
    public interface IDriverDeleteService
    {
        Task DeleteAsync(IDriverId driver);
    }
}