using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    class EthAddressActionImpl
    {
        public static async Task<IResult<IEthAddress>> Execute(MetaConnector connector, string playerID) => await connector.ProcessRequest<IEthAddress,EthAddressEntity>(connector.FindRoute(Routes.Routes.GET_ETH_ADDRESS), endpointParams: new[] { playerID });
    }
}
