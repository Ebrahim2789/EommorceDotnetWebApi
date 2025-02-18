using Ecommorce.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommorce.Model.NewFolder
{
    public class CoreMenu:Common
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        [JsonIgnore]
        public virtual  CoreMenu CoreMenus { get; set; }
        public required string ModelName { get; set; }
        public required string ShortName { get; set; }
        public required string IconUrl { get; set; }
        public required string Path { get; set; }
        public bool Visible { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}






