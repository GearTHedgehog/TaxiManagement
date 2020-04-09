using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class DriverIdModel:IDriverId
    {
        public int DriverId { get; }

        public DriverIdModel(int id)
        {
            this.DriverId = id;
        }
    }
}