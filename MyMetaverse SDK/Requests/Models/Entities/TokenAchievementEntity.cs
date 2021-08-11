using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    class TokenAchievementEntity : ITokenAchievement
    {
        [JsonProperty]
        private string name;
        [JsonProperty]
        private object value;
        public string GetName() => name;
        public object getValue() => value;
    }
}
