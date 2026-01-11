using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core
{
    public class ApiResponse<T>
    {
        public bool Status { get; init; }
        public string Message { get; init; }
        public T? Result { get; init; }

        public ApiResponse(bool status, string message, T? result)
        {
            Status = status;
            Message = message;
            Result = result;
        }
    }

}
