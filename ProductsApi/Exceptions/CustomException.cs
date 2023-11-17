using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Runtime.Serialization;

namespace ProductsApi.Exceptions
{
    public class CustomException : Exception, ISerializable
    {
        public string ErrorName { get; set; }

        public List<string> Messages { get; set; }

        public int StatusCode { get; set; }

        public CustomException() { }
        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ErrorName = info.GetString("ErrorName");
            Messages = new List<string>();
            StatusCode = info.GetInt32("StatusCode");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Errorname", ErrorName);
            info.AddValue("Messages", Messages);
            info.AddValue("StatusCode", StatusCode);
            base.GetObjectData(info, context);
        }
    }
}
