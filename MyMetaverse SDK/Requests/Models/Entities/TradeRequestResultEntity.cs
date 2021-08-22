using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class TradeRequestResultEntity : ITradeRequestResult
    {
        [JsonProperty]
        private string id;
        [JsonProperty]
        private string status;
        public string GetID() => id;
        public string GetStatus() => status;
    }
}
