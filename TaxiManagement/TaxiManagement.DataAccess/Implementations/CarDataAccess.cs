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
using Car = TaxiManagement.Domain.Car;

namespace TaxiManagement.DataAccess.Implementations
{
    public class CarDataAccess : ICarDataAccess
    {
        private TaxiManagementContext Context { get; }
        private IMapper Mapper { get; }

        public CarDataAccess(TaxiManagementContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Car> InsertAsync(CarUpdateModel car)
        {
            var result = await this.Context
                .AddAsync(this.Mapper.Map<Car>(car));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Domain.Car>(result.Entity);
        }

        private async Task<DataAccess.Entities.Car> Get(ICarId car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            return await this.Context.Car.Include(x => x.Depot)
                .FirstOrDefaultAsync(x => x.Id == car.CarId);
        }

        public async Task<IEnumerable<Car>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Car>>(
                await this.Context.Car.Include(x => x.Depot).ToListAsync());
        }

        public async Task<Car> GetAsync(ICarId carId)
        {
            var result = await this.Get(carId);
            return this.Mapper.Map<Domain.Car>(result);
            throw new NotImplementedException();
        }

        public async Task<Car> GetByAsync(ICarId carId)
        {
            throw new NotImplementedException();
        }

        public async Task<Car> UpdateAsync(CarUpdateModel car)
        {
            var found = await this.Get(car);
            var result = this.Mapper.Map(car, found);
            this.Context.Update(result);
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Domain.Car>(result);
        }

        public Task DeleteAsync(ICarId car)
        {
            throw new NotImplementedException();
        }
    }
}