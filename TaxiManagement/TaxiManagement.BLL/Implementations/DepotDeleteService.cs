﻿using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class DepotDeleteService:IDepotDeleteService
    {
        private IDepotDataAccess DepotDataAccess { get; }
        public DepotDeleteService(IDepotDataAccess depotDataAccess)
        {
            this.DepotDataAccess = depotDataAccess;
        }
        
        public Task DeleteAsync(IDepotId depot)
        {
            return this.DepotDataAccess.DeleteAsync(depot);
        }
    }
}