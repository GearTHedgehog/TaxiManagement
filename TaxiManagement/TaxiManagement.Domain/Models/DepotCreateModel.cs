using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain.Models
{
    public class DepotCreateModel:IDepotId
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}