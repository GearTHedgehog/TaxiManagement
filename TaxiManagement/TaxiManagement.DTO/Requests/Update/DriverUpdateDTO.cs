using TaxiManagement.DTO.Requests.Create;

namespace TaxiManagement.DTO.Requests.Update
{
    public class DriverUpdateDTO:DriverCreateDTO
    {
        public int Id { get; set; }
    }
}