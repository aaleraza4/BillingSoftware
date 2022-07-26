using System;

namespace Billing.DTOs.DTOs
{
    public class ResponseDTO
    {
        public dynamic Response { get; set; }
        public bool IsSuccessful { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
    }
}
