using MyMetaverse_SDK.Requests;
using MyMetaverse_SDK.Requests.Models;
using MyMetaverse_SDK.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK
{
    public class MetaAPI
    {
        private TokenResponse _token; 
        private MetaConnector _connector;
        private string client_id;
        private string client_secret;

        public MetaAPI()
        {
            RoutesHub routes = new RoutesHub();
            _connector = new MetaConnector(routes);
        }
        public MetaAPI(RouteAdapter customRouting)
        {
            _connector = new MetaConnector(customRouting);
        }
        public MetaAPI WithCredentials(string client_id,string client_secret)
        {
            this.client_id = client_id;
            this.client_secret = client_secret;
            return this;
        }
        public MetaAPI WithStaticToken(string token)
        {
            _token = new TokenResponse();
            _token.accessToken = token;
            return this;
        }
        public async Task<MetaAPI> Build()
        {
            if (!string.IsNullOrEmpty(client_id) && !string.IsNullOrEmpty(client_secret))
                _token = await _connector.RequestToken(client_id, client_secret);
            else if (_token != null && !string.IsNullOrEmpty(_token.accessToken))
                return this;
            else
                throw new Exception("Missing Credentials or Static token.");

            return this;
        }

        public async Task<TokenResponse> RequestToken()
        {
            if (!string.IsNullOrEmpty(client_id) && !string.IsNullOrEmpty(client_secret))
                _token = await _connector.RequestToken(client_id, client_secret);
            else
                throw new Exception("Client_id or Client_secret is missing, Please use [WithCredentials(string client_id, string client_secret)] to supply the missing values");
            return _token;
        }
        public async Task<TokenResponse> RefreshToken()
        {
            if (_token != null && !string.IsNullOrEmpty(_token.refreshToken))
                _token = await _connector.RefreshToken(_token.refreshToken);
            else
                throw new Exception("Refresh token is missing.");

            return _token;
        }
        public TokenResponse GetToken() => _token;
    }
}
