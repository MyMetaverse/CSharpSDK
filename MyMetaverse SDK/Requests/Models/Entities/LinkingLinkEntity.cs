using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class LinkingLinkEntity : ILinkingLink
    {
        [JsonProperty]
        private string linkingLink;
        [JsonProperty]
        private string linkId;

        public string GetLinkId() => linkId;

        public string GetLinkingLink() => linkingLink;
    }
}
