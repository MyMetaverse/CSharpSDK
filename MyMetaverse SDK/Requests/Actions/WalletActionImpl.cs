using MyMetaverse_SDK.Extensions;
using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using MyMetaverse_SDK.Requests.Models.Requests;
using MyMetaverse_SDK.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class WalletActionImpl
    {
        public static async Task<IResult<IPlayerWallet>> Execute(MetaConnector connector, string playerID)
        {
            return await connector.ProcessRequest<IPlayerWallet, PlayerWalletEntity>(connector.FindRoute(Routes.Routes.GET_WALLET), endpointParams: new[] { playerID });
        }
    }
}
