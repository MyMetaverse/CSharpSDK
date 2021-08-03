using MyMetaverse_SDK.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Token
{
    public class OAuthToken
    {
        private TokenHandler tokenHandler;
        public OAuthToken()
        {

        }
        public OAuthToken(TokenHandler handler)
        {
            tokenHandler = handler;
        }
        public static async Task<OAuthToken> CreateAsync(string client_id,string client_secret)
        {
            RoutesHub routesHub = new RoutesHub("https://devcloud.mymetaverse.io/");
            TokenHandler tokenHandler = new TokenHandler(client_id, client_secret, routesHub);
            await tokenHandler.Create();
            return new OAuthToken(tokenHandler);
        }
        public static async Task<OAuthToken> CreateAsync(string client_id, string client_secret,RouteAdapter routes)
        {
            TokenHandler tokenHandler = new TokenHandler(client_id, client_secret, routes);
            await tokenHandler.Create();
            return new OAuthToken(tokenHandler);
        }

        public async Task<bool> RefreshToken() => await tokenHandler.RefreshToken();
        public async Task<string> GetTokenAsync()
        {
            return await tokenHandler.GetToken();
        }
    }
}
