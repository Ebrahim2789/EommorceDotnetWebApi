using Ecommorce.Model.NewFolder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.NewFolder
{
    public class CoreMenu:Common
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string ModelName { get; set; }
        public string ShortName { get; set; }
        public string IconUrl { get; set; }
        public string Path { get; set; }
        public bool Visible { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}






