using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Actions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    class TokenMetadataEntity : ITokenMetadata
    {
        [JsonProperty]
        private string tokenId;
        [JsonProperty]
        private string tokenIndex;
        [JsonProperty]
        private string name;
        [JsonProperty]
        private string description;
        [JsonProperty]
        private string imageURL;
        [JsonProperty]
        private object properties;
        [JsonProperty]
        private object hiddenProperties;
        [JsonProperty]
        private int amount;

        private MetaConnector _connector;
        public TokenMetadataEntity(MetaConnector connector,string id,string index)
        {
            this.tokenId = id;
            this.tokenIndex = index;
            _connector = connector;
        }
        public IUpdateTokenAchievementsAction CreateTokenAchievementEditor() => new UpdateTokenAchievementsActionImpl(_connector, tokenId ,tokenIndex);
        public IUpdateTokenAction CreateTokenEditor() => new UpdateTokenActionImpl(_connector, tokenId, tokenIndex);

        public object GetHiddenProperties() => hiddenProperties;

        public string GetImageURL() => imageURL;

        public string GetDescription() => description;

        public string GetID() => tokenId;

        public string GetIndex() => tokenIndex;

        public string GetName() => name;

        public object GetProperties() => properties;

        public int GetAmount() => amount;
    }
}
