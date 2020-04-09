using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Contracts
{
    public interface IDepotGetService
    {
        Task<Depot> GetAsync(IDepotId depot);
        Task<IEnumerable<Depot>> GetAsync();
        Task ValidateAsync(IDepotId depot);

    }
}