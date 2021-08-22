using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class WalletItemEntity : IWalletItem
    {
        [JsonProperty]
        private string name;
        [JsonProperty]
        private string tokenId;
        [JsonProperty]
        private IEnumerable<string> indices;
        [JsonProperty]
        private bool nft;
        [JsonProperty]
        private int amount;
        [JsonProperty]
        private string itemURI;
        //public string name { get; set; }
        //public string tokenId { get; set; }
        //public IEnumerable<string> indices { get; set; }
        //public bool nft { get; set; }
        //public int amount { get; set; }
        //public string itemURI { get; set; }

        public int GetAmount() => amount;

        public string GetMetadata() => itemURI;

        public string GetName() => name;

        public string GetTokenId() => tokenId;

        public IEnumerable<IItemIndex> GetTokenIndexes() => (indices != null) ? indices.Select(idx => new ItemIndexEntity(idx)) : Enumerable.Empty<IItemIndex>();

        public bool IsNFT() => nft;

        public JsonObject ToJson()
        {
            var mainObj = new JsonObject();

            mainObj.Add("name", name);
            mainObj.Add("tokenId", tokenId);
            mainObj.Add("indices", indices);
            mainObj.Add("nft", nft);
            mainObj.Add("amount", amount);
            mainObj.Add("itemURI", itemURI);

            return mainObj;
        }
    }
}
