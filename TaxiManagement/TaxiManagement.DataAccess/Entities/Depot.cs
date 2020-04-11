using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiManagement.DataAccess.Entities
{
    public class Depot
    {
        public Depot()
        {
            this.Car = new HashSet<Car>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Address { get; set; }
        
        public virtual ICollection<Car> Car { get; set; }
    }
}