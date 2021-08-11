using MyMetaverse_SDK.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaAPI.Tests
{
    public class CustomRoutes : RouteAdapter
    {
        public CustomRoutes(string baseUrl) : base(baseUrl)
        {
            routes.Add(
               Routes.GEN_TOKEN,
               new Route(RestSharp.Method.POST, "devs/GetAccessToken", false)
               .AddDynamicParams("email")
               .AddDynamicParams("password")
               );

            routes.Add(
                Routes.REFRESH_TOKEN,
                new Route(RestSharp.Method.POST, "oauth2/token", false)
                .AddFixedParams("grant_type", "refresh_token")
                .AddDynamicParams("refresh_token")
                );

            routes.Add(Routes.GET_WALLET, new Route(RestSharp.Method.GET, "LiveWallet/GetItems/{0}"));
           
        }
    }
}
