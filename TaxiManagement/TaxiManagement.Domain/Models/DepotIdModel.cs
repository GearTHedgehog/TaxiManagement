using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class DepotIdModel:IDepotId
    {
        public int DepotId { get; }

        public DepotIdModel(int id)
        {
            this.DepotId = id;
        }
    }
}