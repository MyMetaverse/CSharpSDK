using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Requests
{
    public class RequestError
    {
        public string error { get; set; }
        public string error_description { get; set; }
        public string message { get; set; }
    }
}
