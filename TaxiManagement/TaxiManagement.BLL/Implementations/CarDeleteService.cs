using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class CarDeleteService:ICarDeleteService
    {
        public Task DeleteAsync(ICarId car)
        {
            throw new System.NotImplementedException();
        }
    }
}