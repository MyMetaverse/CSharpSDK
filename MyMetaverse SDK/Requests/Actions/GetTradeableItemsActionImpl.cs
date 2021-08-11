using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class GetTradeableItemsActionImpl
    {
        public static async Task<ITradeableItems> Execute(MetaConnector connector, string initID,string recID)
        {
            var response = await connector.ProcessRequest<TradeableItemsEntity>(connector.FindRoute(Routes.Routes.GET_TRADEABLE_ITEMS), endpointParams: new[] { initID, recID });
            if (response.IsSuccessful)
                return response.Data;
            else
                throw response.Exception();
        }
    }
}
