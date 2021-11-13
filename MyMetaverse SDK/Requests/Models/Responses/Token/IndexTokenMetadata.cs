using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Responses
{
    public class IndexTokenMetadata : BaseToken
    {
        public Dictionary<string, object> properties;
        public Dictionary<string, object> hiddenProperties;
    }
}
