using MyMetaverse_SDK.Requests.Models.Responses;
using MyMetaverse_SDK.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Token
{
    public class TokenHandler : BaseConnector, ITokenHandler
    {
        const string BASE_URL = "https://devcloud.mymetaverse.io/";

        private TokenResponse token;
        private long tokenExpireTime = 0;
        private string client_id;
        private string client_secret;
        private RouteAdapter routes;
        public TokenHandler(string client_id,string client_secret, RouteAdapter routes) : base(routes.BaseUrl)
        {
            this.client_secret = client_secret;
            this.client_id = client_id;
            this.routes = routes;
        }
        public TokenHandler(string client_id, string client_secret) : base(BASE_URL)
        {
            this.client_secret = client_secret;
            this.client_id = client_id;
            this.routes = new RoutesHub(BASE_URL);
        }
        public async Task<bool> CreateToken()
        {
            var response = await ProcessRequest<TokenResponse>(routes.GetRoute(Routes.Routes.GEN_TOKEN),  dynamicParams: new[] { client_id, client_secret });

            if (response.IsSuccessful()) {
                token = response.Data();
                tokenExpireTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() + response.Data().expires_in;
                return true;
            }
            else
                throw response.Exception();
        }
        public async Task<bool> RefreshToken()
        {
            var response = await ProcessRequest<TokenResponse>(routes.GetRoute(Routes.Routes.REFRESH_TOKEN), dynamicParams: new[] { token.refresh_token });

            if (response.IsSuccessful())
            {
                token = response.Data();
                tokenExpireTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() + response.Data().expires_in;
                return true;
            }
            else
                throw response.Exception();
        }
        public async Task<string> GetToken()
        {
            if (ShouldUpdateToken())
                await RefreshToken();

            return token.access_token;
        }
        private bool ShouldUpdateToken()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds() > tokenExpireTime;
        }
    }
}
