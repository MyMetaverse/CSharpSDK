using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Requests;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class PlayerWalletEntity : IPlayerWallet
    {
        [JsonProperty]
        private IEnumerable<WalletItemEntity> liveWallet;
        [JsonProperty]
        private IEnumerable<WalletItemEntity> enjinWallet;
        public IEnumerable<IWalletItem> GetEnjinWallet() => liveWallet;
        public IEnumerable<IWalletItem> GetMyMetaverseWallet() => enjinWallet;

        public JsonObject ToJson()
        {
            var mainObject = new JsonObject();

            IEnumerable<JsonObject> liveItems = liveWallet.Select(i => i.ToJson());
            IEnumerable<JsonObject> enjinItems = enjinWallet.Select(i => i.ToJson());

            mainObject.Add("liveWallet", liveItems);
            mainObject.Add("enjinWallet", enjinItems);

            return mainObject;
        }
    }
}
