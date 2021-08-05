using MyMetaverse_SDK.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests
{
    public class RoutesHub : RouteAdapter
    {
        public RoutesHub(string baseUrl) : base(baseUrl)
        {
            routes.Add(
                Routes.Routes.GEN_TOKEN, 
                new Route(RestSharp.Method.POST, "oauth2/token",false)
                .AddFixedParams("grant_type", "client_credentials")
                .AddDynamicParams("client_id")
                .AddDynamicParams("client_secret")
                );

            routes.Add(
                Routes.Routes.REFRESH_TOKEN,
                new Route(RestSharp.Method.POST, "oauth2/token",false)
                .AddFixedParams("grant_type", "refresh_token")
                .AddDynamicParams("refresh_token")
                );

            routes.Add(Routes.Routes.GET_WALLET, new Route(RestSharp.Method.GET, "users/{0}/wallet"));
            routes.Add(Routes.Routes.GET_ETH_ADDRESS, new Route(RestSharp.Method.GET, "users/{0}/ethereum-address"));

            routes.Add(Routes.Routes.CREATE_LINKING_LINK, new Route(RestSharp.Method.GET, "users/{0}/linking-link"));
            routes.Add(Routes.Routes.GET_LINKING_LINK, new Route(RestSharp.Method.GET, "users/{0}/linking-link"));
        }
    }
}
