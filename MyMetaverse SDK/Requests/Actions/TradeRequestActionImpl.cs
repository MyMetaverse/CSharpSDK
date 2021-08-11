using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class TradeRequestActionImpl
    {
        public static async Task<TradeRequestEntity> Execute(MetaConnector connector,string initID,string recID,IEnumerable<IWalletItem> itemsToOffer, IEnumerable<IWalletItem> itemsToAsk = null)
        {
            var response = await connector.ProcessRequest<TradeRequestEntity>(connector.FindRoute(Routes.Routes.SEND_TRADE_REQUEST), endpointParams: new[] { initID },jsonBody: new object[] { recID,itemsToOffer,itemsToAsk });

            if (response.IsSuccessful)
                return response.Data;
            else
                throw response.Exception();
        }
    }
}
