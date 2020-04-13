using System.ComponentModel.DataAnnotations;

namespace TaxiManagement.DTO.Requests.Create
{
    public class DriverCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int? CarId { get; set; }
    }
}