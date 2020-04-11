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
using Driver = TaxiManagement.Domain.Driver;

namespace TaxiManagement.DataAccess.Implementations
{
    public class DriverDataAccess : IDriverDataAccess
    {
        private TaxiManagementContext Context { get; }
        private IMapper Mapper { get; }

        public DriverDataAccess(TaxiManagementContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Driver> InsertAsync(DriverUpdateModel driver)
        {
            var result = await this.Context
                .AddAsync(this.Mapper.Map<Driver>(driver));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Domain.Driver>(result.Entity);
        }

        private async Task<DataAccess.Entities.Driver> Get(IDriverId driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }

            return await this.Context.Driver.Include(x => x.Car)
                .FirstOrDefaultAsync(x => x.DriverId == driver.DriverId);
        }

        public async Task<IEnumerable<Driver>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Driver>>(
                await this.Context.Driver.Include(x => x.Car).ToListAsync());
        }

        public async Task<Driver> GetAsync(IDriverId driverId)
        {
            var result = await this.Get(driverId);
            return this.Mapper.Map<Domain.Driver>(result);
        }

        public async Task<Driver> UpdateAsync(DriverUpdateModel driver)
        {
            var found = await this.Get(driver);
            var result = this.Mapper.Map(driver, found);
            this.Context.Update(result);
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Domain.Driver>(result);
        }

        public async Task DeleteAsync(IDriverId driver)
        {
            var result = this.Context.Remove(this.Mapper.Map<Driver>(driver));
            await this.Context.SaveChangesAsync();
        }
    }
}