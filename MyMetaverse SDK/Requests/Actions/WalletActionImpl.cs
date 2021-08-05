using MyMetaverse_SDK.Meta.Entites;
using MyMetaverse_SDK.Requests.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class WalletActionImpl
    {
        public static async Task<PlayerWalletEntity> execute(MetaConnector connector,string playerID)
        {
            var result = await connector.ProcessRequest<PlayerWalletEntity>(connector.FindRoute(Routes.Routes.GET_WALLET), endpointParams: new[] { playerID });
            return result.Data;
        }
    }
}
