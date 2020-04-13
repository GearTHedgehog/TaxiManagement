using System.ComponentModel.DataAnnotations;

namespace TaxiManagement.DTO.Requests.Create
{
    public class CarCreateDTO
    {
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int CurrentRepairs { get; set; }
        public int? DepotId { get; set; }
    }
}