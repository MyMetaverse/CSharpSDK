using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    }
}
