using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class DepotGetService:IDepotGetService
    {
        public Task<IEnumerable<Depot>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Depot> GetAsync(IDepotId depot)
        {
            throw new System.NotImplementedException();
        }

        public Task ValidateAsync(IDepotContainer depot)
        {
            throw new System.NotImplementedException();
        }
    }
}