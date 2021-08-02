using MyMetaverse_SDK.Requests.Models;
using MyMetaverse_SDK.Requests.Routes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests
{
    public class MetaConnector : BaseConnector
    {
        private RouteAdapter routing;
        private TokenResponse _token;
        public MetaConnector(RouteAdapter adapter) : base(adapter.BaseUrl)
        {
            routing = adapter;
        }

        public async Task<TokenResponse> RequestToken(string client_id, string client_secret)
        {
            Route route = routing.GetRoute(Routes.Routes.GEN_TOKEN);
            var response = await ProcessRequest<TokenResponse>(route, parameters: new[] { client_id, client_secret });

            if (response.IsSuccessful)
                return response.Data;
            else
                throw response.Exception();
        }
        public async Task<TokenResponse> RefreshToken(string refreshToken)
        {
            Route route = routing.GetRoute(Routes.Routes.REFRESH_TOKEN);
            var response = await ProcessRequest<TokenResponse>(route, parameters: new[] { refreshToken });

            if (response.IsSuccessful)
                return response.Data;
            else
                throw response.Exception();
        }
    }
}
