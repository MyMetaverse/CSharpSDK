using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class EthAddressEntity : IEthAddress
    {
        [JsonProperty]
        private string address;
        public string GetAddress() => address;
        public bool IsLinked() => !address.Equals("Not Linked", StringComparison.OrdinalIgnoreCase);
    }
}
