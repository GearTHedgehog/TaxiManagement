using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaxiManagement.DataAccess.Context;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.DataAccess.Entities;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Depot = TaxiManagement.Domain.Depot;

namespace TaxiManagement.DataAccess.Implementations
{
    public class DepotDataAccess : IDepotDataAccess
    {
        private TaxiManagementContext Context { get; }
        private IMapper Mapper { get; }

        public DepotDataAccess(TaxiManagementContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Depot> InsertAsync(DepotCreateModel depot)
        {
            var result = await this.Context
                .AddAsync(this.Mapper.Map<Depot>(depot));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Domain.Depot>(result.Entity);
        }

        private async Task<DataAccess.Entities.Depot> Get(IDepotId depot)
        {
            if (depot == null)
            {
                throw new ArgumentNullException(nameof(depot));
            }

            return await this.Context.Depot.FirstOrDefaultAsync(x => x.Id == depot.DepotId);
        }

        public async Task<IEnumerable<Depot>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Depot>>(
                await this.Context.Depot.ToListAsync());
        }

        public async Task<Depot> GetAsync(IDepotId depotId)
        {
            var result = await this.Get(depotId);
            return this.Mapper.Map<Domain.Depot>(result);
        }

        public async Task<Depot> GetByAsync(IDepotContainer depotId)
        {
            return depotId.DepotContainer.HasValue
                ? this.Mapper.Map<Domain.Depot>(
                    await this.Context.Depot.FirstOrDefaultAsync(x => x.Id == depotId.DepotContainer))
                : null;
        }
        
        public async Task DeleteAsync(IDepotId depot)
        {
            var found = await this.Get(depot);
            var result = this.Context.Remove(found);
            await this.Context.SaveChangesAsync();
        }
    }
}