using System.ComponentModel.DataAnnotations;

namespace TaxiManagement.DTO.Requests.Create
{
    public class DepotCreateDTO
    {
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}