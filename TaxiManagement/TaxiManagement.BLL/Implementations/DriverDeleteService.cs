using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class DriverDeleteService:IDriverDeleteService
    {
        public Task DeleteAsync(IDriverId driver)
        {
            throw new System.NotImplementedException();
        }
    }
}