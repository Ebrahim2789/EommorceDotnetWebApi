using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Outgoing
{
    public class IDriverDto
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public int DriverNumber { get; set; }
        public int WorldChampionships { get; set; }
    }
}
