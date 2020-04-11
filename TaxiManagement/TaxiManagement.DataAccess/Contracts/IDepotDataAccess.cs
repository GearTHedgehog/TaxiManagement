using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.DataAccess.Contracts
{
    public interface IDepotDataAccess
    {
        Task<Depot> GetByAsync(IDepotContainer depotId);
        Task<Depot> InsertAsync(DepotCreateModel depot);
        Task DeleteAsync(IDepotId depotId);
        Task<Depot> GetAsync(IDepotId depotId);
        Task<IEnumerable<Depot>> GetAsync();
    }
}