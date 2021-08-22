using MyMetaverse_SDK.Meta.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Requests
{
    public class Result<T> : IResult<T>
    {
        private bool isSuccessful;
        private RequestError error;
        private T data;
        public Result(T data, bool isSuccessful, RequestError error = null)
        {
            this.data = data;
            this.isSuccessful = isSuccessful;
            this.error = error;
        }
        public bool IsSuccessful() => isSuccessful;
        public T Data() => data;

        public string GetErrorMessage() => error.message ?? error.error_description + " " + error.error;

        public Exception Exception()
        {
            if (!string.IsNullOrEmpty(error.message))
                return new ApplicationException(error.message + " " + error.details);
            else if (!string.IsNullOrEmpty(error.error) || !string.IsNullOrEmpty(error.error_description))
                return new ApplicationException(error.error, new ApplicationException(error.error_description));
            else
                return new ApplicationException("Unknown error occurred!");
        }
    }
}
