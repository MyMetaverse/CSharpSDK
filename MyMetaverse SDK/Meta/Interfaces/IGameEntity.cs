using MyMetaverse_SDK.Meta.Models;
using MyMetaverse_SDK.Requests.Models.Requests;
using MyMetaverse_SDK.Requests.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IGameEntity
    {
        string GetPlayerID();
        Task<IResult<IPlayerWallet>> FetchWallet();
        Task<IResult<IEthAddress>> FetchEthAddress();
        Task<IResult<ILinkingLink>> GetLinkingLink();
        Task<IResult<ILinkingLink>> CreateLinkingLink(LinkingDetails details);
        Task<IResult<ITradeableItems>> GetTradeableItems(IGameEntity target);
        Task<IResult<ITradeRequestResult>> SendTradeRequest(IGameEntity target, IEnumerable<IWalletItem> itemsToOffer, IEnumerable<IWalletItem> itemsToAsk = null);
        Task<IResult<BasicResponse>> Deposit(IEnumerable<ITokenMetadata> tokens);
    }
}
