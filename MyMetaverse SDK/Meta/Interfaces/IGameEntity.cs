using MyMetaverse_SDK.Meta.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IGameEntity
    {
        string GetPlayerID();
        Task<IPlayerWallet> FetchWallet();
        Task<IEthAddress> FetchEthAddress();
        Task<ILinkingLink> GetLinkingLink();
        Task<ILinkingLink> CreateLinkingLink(LinkingDetails details);
        Task<ITradeableItems> GetTradeableItems(IGameEntity target);
        Task<ITradeRequest> SendTradeRequest(IGameEntity target, IEnumerable<IWalletItem> itemsToOffer, IEnumerable<IWalletItem> itemsToAsk = null);
    }
}
