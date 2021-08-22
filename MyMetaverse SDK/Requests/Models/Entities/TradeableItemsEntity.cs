using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class TradeableItemsEntity : ITradeableItems
    {
        [JsonProperty]
        private IEnumerable<WalletItemEntity> initiatorWallet;
        [JsonProperty]
        private IEnumerable<WalletItemEntity> receiverWallet;

        public IEnumerable<IWalletItem> GetInitiatorItems() => initiatorWallet;

        public IEnumerable<IWalletItem> GetReceiverItems() => receiverWallet;

        public JsonObject Tojson()
        {
            var mainObject = new JsonObject();

            IEnumerable<JsonObject> initItems = initiatorWallet.Select(i => i.ToJson());
            IEnumerable<JsonObject> recItems = receiverWallet.Select(i => i.ToJson());

            mainObject.Add("initiatorWallet", initItems);
            mainObject.Add("receiverWallet", recItems);

            return mainObject;
        }
    }
}
