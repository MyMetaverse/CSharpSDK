using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Requests
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
        public RequestResult(bool isSuccessful, RequestError error = null)
        {
            IsSuccessful = isSuccessful;
            Error = error;
        }

        public Exception Exception()
        {
            if (!string.IsNullOrEmpty(Error.message))
                return new ApplicationException(Error.message);
            else if (!string.IsNullOrEmpty(Error.error) || !string.IsNullOrEmpty(Error.error_description))
                return new ApplicationException(Error.error, new ApplicationException(Error.error_description));
            else
                return new ApplicationException("Unknown error occurred!");
        }
    }
}
