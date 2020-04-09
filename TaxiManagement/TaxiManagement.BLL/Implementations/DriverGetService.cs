using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class DriverGetService:IDriverGetService
    {
        public Task<IEnumerable<Driver>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Driver> GetAsync(IDriverId driver)
        {
            throw new System.NotImplementedException();
        }
    }
}