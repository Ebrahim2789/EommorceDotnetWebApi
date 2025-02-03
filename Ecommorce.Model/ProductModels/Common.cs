using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.ProductModels
{
    public class Common
    {
        public bool IsDelete { get; set; }
        public DateTime CreateOnd { get; set; } = DateTime.Now;
        public DateTime UpdateOn { get; set; } = DateTime.Now;
    }
}
