﻿using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using MyMetaverse_SDK.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class WalletActionImpl
    {
        public static async Task<PlayerWalletEntity> Execute(MetaConnector connector,string playerID)
        {
            var response = await connector.ProcessRequest<PlayerWalletEntity>(connector.FindRoute(Routes.Routes.GET_WALLET), endpointParams: new[] { playerID });
            if (response.IsSuccessful)
                return response.Data;
            else
                throw response.Exception();
        }
    }
}
