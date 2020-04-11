using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class CarUpdateModel : ICarId, IDepotContainer
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int CurrentRepairs { get; set; }

        public int? DepotContainer { get; set; }
    }
}