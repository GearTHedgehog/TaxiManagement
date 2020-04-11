using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.DataAccess.Contracts
{
    public interface IDriverDataAccess
    {
        Task<Driver> InsertAsync(DriverUpdateModel driver);
        Task<IEnumerable<Driver>> GetAsync();
        Task<Driver> GetAsync(IDriverId driverId);
        Task<Driver> UpdateAsync(DriverUpdateModel driver);
        Task DeleteAsync(IDriverId driverId);
    }
}