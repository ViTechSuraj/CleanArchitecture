using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ApiResponse
{
    public interface IApiResponseInterface
    {
        ApiResponse<T> Success<T>(T result, string message = "Success");
        ApiResponse<T> Failure<T>(string message, T? result = default);
    }
}
