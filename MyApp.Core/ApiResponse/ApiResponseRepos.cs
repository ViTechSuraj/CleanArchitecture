using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ApiResponse
{
    public class ApiResponseRepos : IApiResponseInterface
    {
        public ApiResponse<T> Success<T>(T result, string message = "Success")
        {
            return new ApiResponse<T>(true, message, result);
        }

        public ApiResponse<T> Failure<T>(string message, T? result = default)
        {
            return new ApiResponse<T>(false, message, result);
        }
    }
}
