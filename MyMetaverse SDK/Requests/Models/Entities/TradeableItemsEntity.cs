using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    }
}
