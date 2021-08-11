using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class WalletItemEntity : IWalletItem
    {
        [JsonProperty]
        public string name;
        [JsonProperty]
        public string tokenId;
        [JsonProperty]
        public IEnumerable<string> indices;
        [JsonProperty]
        public bool nft;
        [JsonProperty]
        public int amount;
        [JsonProperty]
        public string itemuri;

        //override
        //public string ToString()
        //{
        //    return "WalletItemImpl{" +
        //        " name='" + name + '\'' +
        //        ", tokenId='" + tokenId + '\'' +
        //        ", tokenIndexes=[" + ((indices != null) ? string.Join(",",indices.ToArray()) : "") +"]"+
        //        ", NFT=" + nft +
        //        ", amount=" + amount +
        //        ", metadata='" + itemuri + '\'' +
        //        '}';
        //}
        public int GetAmount() => amount;

        public string GetMetadata() => itemuri;

        public string GetName() => name;

        public string GetTokenId() => tokenId;

        public IEnumerable<IItemIndex> GetTokenIndexes() => (indices != null) ? indices.Select(idx => new ItemIndexEntity(idx)) : Enumerable.Empty<IItemIndex>();

        public bool IsNFT() => nft;
    }
}
