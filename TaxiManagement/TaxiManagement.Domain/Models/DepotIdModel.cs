using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class DepotIdModel:IDepotId
    {
        public int Id { get; }

        public DepotIdModel(int id)
        {
            this.Id = id;
        }
    }
}