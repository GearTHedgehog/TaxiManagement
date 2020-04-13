namespace TaxiManagement.DTO.DTO
{
    public class DriverDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public CarDTO Car { get; set; }
    }
}