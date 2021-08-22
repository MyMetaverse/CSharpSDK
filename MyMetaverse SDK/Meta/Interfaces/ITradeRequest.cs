using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface ITradeRequest
    {
        string GetInitiatorPlayerID();
        string GetReceiverPlayerID();
        IEnumerable<IWalletItem> GetItemsToOffer();
        IEnumerable<IWalletItem> GetItemsToAsk();
        JsonObject ToJson();
    }
}
