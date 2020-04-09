using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class DepotCreateService:IDepotCreateService
    {
        public Task<Depot> CreateAsync(DepotCreateModel depot)
        {
            throw new System.NotImplementedException();
        }
    }
}