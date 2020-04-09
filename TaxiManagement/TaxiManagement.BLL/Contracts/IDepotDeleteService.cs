using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Contracts
{
    public interface IDepotDeleteService
    {
        Task DeleteAsync(IDepotId depot);
    }
}