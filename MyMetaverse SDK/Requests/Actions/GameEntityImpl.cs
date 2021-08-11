using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Meta.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    class GameEntityImpl : IGameEntity
    {
        private MetaConnector connector;
        private string playerID;
        public GameEntityImpl(MetaConnector connector,string playerID)
        {
            this.connector = connector;
            this.playerID = playerID;
        }
        public string GetPlayerID() => playerID;
        public async Task<IEthAddress> FetchEthAddress() => await EthAddressActionImpl.Execute(connector, playerID);
        public async Task<IPlayerWallet> FetchWallet() => await WalletActionImpl.Execute(connector, playerID);
        public async Task<ILinkingLink> GetLinkingLink() => await LinkingLinkActionImpl.GetLinkingLink(connector, playerID);
        public async Task<ILinkingLink> CreateLinkingLink(LinkingDetails details) => await LinkingLinkActionImpl.CreateLinkingLink(connector, playerID, details);
        public async Task<ITradeableItems> GetTradeableItems(IGameEntity target) => await GetTradeableItemsActionImpl.Execute(connector, playerID, target.GetPlayerID());
        public async Task<ITradeRequest> SendTradeRequest(IGameEntity target, IEnumerable<IWalletItem> itemsToOffer, IEnumerable<IWalletItem> itemsToAsk = null) => await TradeRequestActionImpl.Execute(connector, playerID, target.GetPlayerID(), itemsToOffer, itemsToAsk);
    }
}
