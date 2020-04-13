using TaxiManagement.DTO.Requests.Create;

namespace TaxiManagement.DTO.Requests.Update
{
    public class CarUpdateDTO:CarCreateDTO
    {
        public int Id { get; set; }
    }
}