using System.Net;
using static Order.Core.Constants.Enums;

namespace Order.Core.RequestResponseModel
{
    public record APIResponseModel
    {
        public dynamic? Data { get; set; }
        public string Message { get; set; }
        public string Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public APIResponseModel(dynamic? data, string message, string errors = null, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            Data = data;
            Message = message;
            Errors = errors;
            StatusCode = httpStatusCode;
        }
    }
}
