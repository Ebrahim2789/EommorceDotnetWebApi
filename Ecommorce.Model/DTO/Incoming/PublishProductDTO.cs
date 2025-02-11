using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{
    public class PublishProductDTO
    {
        public int ProductId { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishTimeFrom { get; set; }
        public DateTime PublishTimeTo { get; set; }
    }
}
