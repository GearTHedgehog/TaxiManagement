namespace TaxiManagement.DTO.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int CurrentRepairs { get; set; }
        public DepotDTO Depot { get; set; }
    }
}