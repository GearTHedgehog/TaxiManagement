using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Contracts
{
    public interface IDriverGetService
    {
        Task<Driver> GetAsync(IDriverId driver);
        Task<IEnumerable<Driver>> GetAsync();
    }
}