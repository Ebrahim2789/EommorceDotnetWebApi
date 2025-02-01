using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommorce.Model.Model
{
    public class Driver : BaseEntity
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        public int DriverNumber { get; set; }
        public DateTime DateAdded { get; set; }= DateTime.Now;
        public DateTime DateUpdated { get; set; }=DateTime.Now;
        public int Status { get; set; }
        public int WorldChampionships { get; set; }

        [InverseProperty(nameof(Car.Drivers))]
        [JsonIgnore]
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
        [InverseProperty(nameof(CarDriver.DriverNavigation))]
        [JsonIgnore]
        public IEnumerable<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();
    }
}
