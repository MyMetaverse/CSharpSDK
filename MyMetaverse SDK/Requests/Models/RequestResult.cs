using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models
{
    public class RequestResult<T>
    {
        public bool IsSuccessful { get; private set; }
        public RequestError Error { get; private set; }
        public T Data { get; set; }
        public RequestResult(bool isSuccessful, T data, RequestError error = null)
        {
            IsSuccessful = isSuccessful;
            Data = data;
            Error = error;
        }

        public Exception Exception()
        {
            return new Exception(Error.error, new Exception(Error.error_description));
        }
    }
}
