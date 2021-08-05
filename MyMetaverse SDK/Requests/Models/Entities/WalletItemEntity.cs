using MyMetaverse_SDK.Meta.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class WalletItemEntity : WalletItem
    {
        [JsonProperty]
        string name;
        [JsonProperty]
        string tokenId;
        [JsonProperty]
        List<string> indices;
        [JsonProperty]
        bool nft;
        [JsonProperty]
        int amount;
        [JsonProperty]
        string itemuri;

        override
        public string ToString()
        {
            return "WalletItemImpl{" +
                " name='" + name + '\'' +
                ", tokenId='" + tokenId + '\'' +
                ", tokenIndexes=[" + ((indices != null) ? string.Join(",",indices.ToArray()) : "") +"]"+
                ", NFT=" + nft +
                ", amount=" + amount +
                ", metadata='" + itemuri + '\'' +
                '}';
        }
        public int getAmount() => amount;

        public string getMetadata() => itemuri;

        public string getName() => name;

        public string getTokenId() => tokenId;

        public List<string> getTokenIndexes() => indices;

        public bool isNFT() => nft;
    }
}
