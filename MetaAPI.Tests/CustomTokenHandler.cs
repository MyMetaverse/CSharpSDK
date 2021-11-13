using MyMetaverse_SDK.Requests;
using MyMetaverse_SDK.Requests.Routes;
using MyMetaverse_SDK.Requests.Token;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetaAPI.Tests
{
    public class CustomTokenHandler : BaseConnector, ITokenHandler
    {
        private string email;
        private string password;
        private RouteAdapter routing;
        private AuthToken token;
        public CustomTokenHandler(string email,string password,RouteAdapter routing) : base(routing.BaseUrl)
        {
            this.email = email;
            this.password = password;
            this.routing = routing;
        }
        public async Task<bool> CreateToken()
        {
            var response = await ProcessRequest<AuthToken>(routing.GetRoute(Routes.GEN_TOKEN), dynamicParams: new[] { email, password });
            if (response.IsSuccessful())
            {
                token = response.Data();
                return true;
            }
            else
                return false;
        }

        public async Task<string> GetToken() => token.AccessToken;

        public async Task<bool> RefreshToken()
        {
            var response = await ProcessRequest<AuthToken>(routing.GetRoute(Routes.GEN_TOKEN), dynamicParams: new[] { email, password });
            if (response.IsSuccessful())
            {
                token = response.Data();
                return true;
            }
            else
                return false;
        }
    }

    class AuthToken
    {
        public string AccessToken { get; set; }
    }
}
