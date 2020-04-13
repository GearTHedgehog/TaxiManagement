using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class CarIdModel:ICarId
    {
        public int Id { get; }

        public CarIdModel(int id)
        {
            this.Id = id;
        }
    }
}