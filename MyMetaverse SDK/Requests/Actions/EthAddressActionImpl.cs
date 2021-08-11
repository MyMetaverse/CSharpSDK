using MyMetaverse_SDK.Requests.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    class EthAddressActionImpl
    {
        public static async Task<EthAddressEntity> Execute(MetaConnector connector, string playerID)
        {
            var response = await connector.ProcessRequest<EthAddressEntity>(connector.FindRoute(Routes.Routes.GET_ETH_ADDRESS), endpointParams: new[] { playerID });

            if (response.IsSuccessful)
                return response.Data;
            else
                throw response.Exception();
        }
    }
}
