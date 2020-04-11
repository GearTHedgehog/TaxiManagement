using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TaxiManagement.DataAccess.Entities
{
    public partial class Car
    {
        public Car()
        {
            this.Driver = new HashSet<Driver>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int CurrentRepairs { get; set; }
        public int DepotId { get; set; }
        public virtual Depot Depot { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
    }
}