using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class DepotGetService:IDepotGetService
    {
        private IDepotDataAccess DepotDataAccess { get; }

        public DepotGetService(IDepotDataAccess depotDataAccess)
        {
            this.DepotDataAccess = depotDataAccess;
        }
        public Task<IEnumerable<Depot>> GetAsync()
        {
            return this.DepotDataAccess.GetAsync();
        }

        public Task<Depot> GetAsync(IDepotId depot)
        {
            return this.DepotDataAccess.GetAsync(depot);
        }

        private async Task<Depot> GetBy(IDepotContainer depotContainer)
        {
            return await this.DepotDataAccess.GetByAsync(depotContainer);
        }
        public async Task ValidateAsync(IDepotContainer depotContainer)
        {
            if (depotContainer == null)
            {
                throw new ArgumentNullException(nameof(depotContainer));
            }

            var depot = await this.GetBy(depotContainer);
            if (depotContainer.DepotId.HasValue && depot == null)
            {
                throw new InvalidOperationException($"Depot not found by id {depotContainer.DepotId}");
            }
        }
    }
}