using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
