using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public JsonObject ToJson()
        {
            var mainObject = new JsonObject();

            mainObject.Add("initiatorPlayerID", initiatorPlayerID);
            mainObject.Add("receiverPlayerID", receiverPlayerID);

            var ito = itemsToOffer.Select(i => i.ToJson());
            var ita = itemsToAsk.Select(i => i.ToJson());

            mainObject.Add("itemsToOffer", ito);
            mainObject.Add("itemsToAsk", ita);

            return mainObject;
        }
    }
}
