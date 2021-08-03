using MyMetaverse_SDK.Requests.Models.Responses;
using MyMetaverse_SDK.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Token
{
    public class TokenHandler : BaseConnector
    {
        public TokenResponse Token { get; private set; }

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
        public async Task<bool> Create()
        {
            var response = await ProcessRequest<TokenResponse>(routes.GetRoute(Routes.Routes.GEN_TOKEN), client_id, client_secret);

            if (response.IsSuccessful) {
                Token = response.Data;
                tokenExpireTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() + response.Data.expiresIn;
                return true;
            }
            else
                throw response.Exception();
        }

        public async Task<bool> RefreshToken()
        {
            var response = await ProcessRequest<TokenResponse>(routes.GetRoute(Routes.Routes.REFRESH_TOKEN), parameters: new[] { Token.refreshToken });

            if (response.IsSuccessful)
            {
                Token = response.Data;
                tokenExpireTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() + response.Data.expiresIn;
                return true;
            }
            else
                throw response.Exception();
        }
        
        public async Task<string> GetToken()
        {
            if (ShouldUpdateToken())
                await RefreshToken();

            return Token.accessToken;
        }
        private bool ShouldUpdateToken()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds() - tokenExpireTime <= 0;
        }
    }
}
