using MyMetaverse_SDK.Meta.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class PlayerWalletEntity : PlayerWallet
    {
        [JsonProperty]
        private IEnumerable<WalletItemEntity> liveWallet;
        [JsonProperty]
        private IEnumerable<WalletItemEntity> enjinWallet;

        public IEnumerable<WalletItem> getEnjinWallet() => liveWallet;

        public IEnumerable<WalletItem> getMyMetaverseWallet() => enjinWallet;
    }
}
