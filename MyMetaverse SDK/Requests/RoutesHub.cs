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

            routes.Add(Routes.Routes.GET_TRADEABLE_ITEMS, new Route(RestSharp.Method.GET, "users/{0}/wallet/transferable/{1}"));

            routes.Add(Routes.Routes.CREATE_LINKING_LINK, new Route(RestSharp.Method.POST, "users/{0}/linking-link").AddJsonBodyObject("details"));
            routes.Add(Routes.Routes.GET_LINKING_LINK, new Route(RestSharp.Method.GET, "users/{0}/linking-link"));

            routes.Add(
                Routes.Routes.SEND_TRADE_REQUEST,
                new Route(RestSharp.Method.POST, "users/{0}/transfers")
                .AddJsonBodyObject("receiverId")
                .AddJsonBodyObject("offeredItems")
                .AddJsonBodyObject("askedItems")
                );

            routes.Add(Routes.Routes.GET_TOKEN_METADATA, new Route(RestSharp.Method.GET, "/tokens/{0}"));
            routes.Add(Routes.Routes.GET_TOKEN_INDEX_METADATA, new Route(RestSharp.Method.GET, "/tokens/{0}/{1}"));

            routes.Add(Routes.Routes.UPDATE_TOKEN_DETAILS, new Route(RestSharp.Method.PUT, "/tokens/{0}"));

            routes.Add(Routes.Routes.DEPOSIT, new Route(RestSharp.Method.POST, "/deposit/"));

            routes.Add(Routes.Routes.UPDATE_INDEX_PROPERTY, new Route(RestSharp.Method.PUT, "/tokens/{0}/indexes/{1}/properties/{2}"));

            routes.Add(Routes.Routes.UPDATE_TOKEN_PROPERTY_SCHEMA, new Route(RestSharp.Method.PUT, "/tokens/{0}/properties"));
        }
    }
}
