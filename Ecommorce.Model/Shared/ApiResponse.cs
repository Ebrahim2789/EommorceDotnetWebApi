using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.Shared
{
 
    public class ApiResponse<T> 
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public string? Token { get;set;}

        public ApiResponse()
        {
            Errors = new List<string>();
        }

        public ApiResponse(T data, bool isSuccess, string message = null, List<string> errors = null)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message ?? (isSuccess ? "Operation successful" : "Operation failed");
            Errors = errors ?? new List<string>();
        }


    }
}
