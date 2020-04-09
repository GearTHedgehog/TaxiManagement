using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class CarIdModel:ICarId
    {
        public int CarId { get; }

        public CarIdModel(int id)
        {
            this.CarId = id;
        }
    }
}