using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Models
{
    public class LinkingDetails
    {
        public string username { get; }
        public string image { get; }
        public string description { get; }
        public LinkingDetails(string userName,string imageUrl,string description)
        {
            this.username = userName;
            image = imageUrl;
            this.description = description;
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }

}
