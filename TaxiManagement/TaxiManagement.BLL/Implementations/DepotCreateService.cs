﻿using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Implementations
{
    public class DepotCreateService:IDepotCreateService
    {
        private IDepotDataAccess DepotDataAccess { get; }

        public DepotCreateService(IDepotDataAccess depotDataAccess)
        {
            this.DepotDataAccess = depotDataAccess;
        }
        public async Task<Depot> CreateAsync(DepotCreateModel depot)
        {
            return await this.DepotDataAccess.InsertAsync(depot);
            throw new System.NotImplementedException();
        }
    }
}