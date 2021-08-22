using MyMetaverse_SDK.Extensions;
using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class TradeRequestActionImpl
    {
        public static async Task<IResult<ITradeRequestResult>> Execute(MetaConnector connector,string initID,string recID,IEnumerable<IWalletItem> itemsToOffer, IEnumerable<IWalletItem> itemsToAsk = null) => await connector.ProcessRequest<ITradeRequestResult, TradeRequestResultEntity>(connector.FindRoute(Routes.Routes.SEND_TRADE_REQUEST), endpointParams: new[] { initID }, jsonBody: new object[] { recID, itemsToOffer.ToJson(), itemsToAsk.ToJson() });
    }
}
