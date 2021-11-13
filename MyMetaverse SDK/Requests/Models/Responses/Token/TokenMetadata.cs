using MyMetaverse_SDK.Requests.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Responses
{
    public class TokenMetadata : BaseToken
    {

        public Dictionary<string, TokenProperty> properties;

        public Dictionary<string, TokenProperty> hiddenProperties;
    }

    public class TokenProperty
    {

        public object content;

        public TokenPropertyConfig config;
    }
    public class TokenPropertyConfig
    {

        public bool editable;

        public bool unique;
    }
}
