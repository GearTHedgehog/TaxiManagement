using System.Threading.Tasks;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Implementations
{
    public class DepotDeleteService:IDepotDeleteService
    {
        public Task DeleteAsync(IDepotId depot)
        {
            throw new System.NotImplementedException();
        }
    }
}