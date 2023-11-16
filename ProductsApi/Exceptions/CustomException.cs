using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ProductsApi.Exceptions
{
    public class CustomException : Exception
    {
        public string ErrorName { get; set; }
        public string ErrorMessage { get; set; }

        public int StatusCode { get; set; }

        public CustomException(string errorName, string errorMessage, int statusCode) 
        {
            ErrorName = errorName;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
