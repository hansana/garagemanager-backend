using GarageManager.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null, ResponseStatus status = ResponseStatus.OK)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            Status = status;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public ResponseStatus Status { get; set; }
    }
}
