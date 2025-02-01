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
    public class Make : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [InverseProperty(nameof(Car.MakeNavigation))]
    
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();

    }
}
