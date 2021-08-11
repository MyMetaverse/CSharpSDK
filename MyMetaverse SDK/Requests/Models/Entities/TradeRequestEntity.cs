using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class TradeRequestEntity : ITradeRequest
    {
        [JsonProperty]
        private string initiatorPlayerID;
        [JsonProperty]
        private string receiverPlayerID;
        [JsonProperty]
        private IEnumerable<WalletItemEntity> itemsToOffer;
        [JsonProperty]
        private IEnumerable<WalletItemEntity> itemsToAsk;

        public string GetInitiatorPlayerID() => initiatorPlayerID;
        public string GetReceiverPlayerID() => receiverPlayerID;
        public IEnumerable<IWalletItem> GetItemsToOffer() => itemsToOffer;
        public IEnumerable<IWalletItem> GetItemsToAsk() => itemsToAsk;
    }
}
