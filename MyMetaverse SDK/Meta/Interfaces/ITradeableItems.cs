using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface ITradeableItems
    {
        IEnumerable<IWalletItem> GetInitiatorItems();
        IEnumerable<IWalletItem> GetReceiverItems();
        JsonObject Tojson();
    }
}
