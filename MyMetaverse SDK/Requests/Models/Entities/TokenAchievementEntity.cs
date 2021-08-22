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
        private props props;
        public ITokenAchievement Build(string name,object value) { this.name = name; this.props = new props() { content = value, config = new TokenAchievementConfig()}; return this; }
        public TokenAchievementConfig Config() => props.config;
        public string GetName() => name;
        public object GetValue() => props.content;
    }

    internal class props
    {
        public object content { get; set; }
        public TokenAchievementConfig config { get; set; }
    }
}
