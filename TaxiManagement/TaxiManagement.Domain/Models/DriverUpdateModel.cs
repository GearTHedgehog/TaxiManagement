using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class DriverUpdateModel:IDriverId, ICarContainer
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        
        public int? CarContainer { get; set; }
    }
}