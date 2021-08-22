using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IWalletItem
    {
        string GetName();
        string GetTokenId();
        bool IsNFT();
        IEnumerable<IItemIndex> GetTokenIndexes();
        int GetAmount();
        string GetMetadata();
        JsonObject ToJson();
    }
}
