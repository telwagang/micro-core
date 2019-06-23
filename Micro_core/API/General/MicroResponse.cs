using System;
using System.Net;

namespace API.General
{
    public class MicroResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public MicroResponse()
        {
            Data = null;
            Status = HttpStatusCode.OK;
            Message = "okay";
        }
        public MicroResponse(object data)
        {
            Data = data;
            Status = HttpStatusCode.OK;
            Message = string.Empty;
        }
        public MicroResponse(object data, string msg)
        {
            Data = data;
            Status = HttpStatusCode.OK;
            Message = msg;
        }
        public MicroResponse(string msg, HttpStatusCode status = HttpStatusCode.NotFound)
        {
            Data = null;
            Status = status;
            Message = msg;
        }
    }
}
