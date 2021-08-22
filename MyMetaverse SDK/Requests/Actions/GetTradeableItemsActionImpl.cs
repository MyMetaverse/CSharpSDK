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
        public static async Task<IResult<ITradeableItems>> Execute(MetaConnector connector, string initID,string recID) => await connector.ProcessRequest<ITradeableItems,TradeableItemsEntity>(connector.FindRoute(Routes.Routes.GET_TRADEABLE_ITEMS), endpointParams: new[] { initID, recID });
    }
}
