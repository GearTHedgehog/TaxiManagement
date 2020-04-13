using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class DriverIdModel:IDriverId
    {
        public int Id { get; }

        public DriverIdModel(int id)
        {
            this.Id = id;
        }
    }
}