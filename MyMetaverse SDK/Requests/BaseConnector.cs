using MyMetaverse_SDK.Requests.Models.Requests;
using MyMetaverse_SDK.Requests.Routes;
using MyMetaverse_SDK.Requests.Token;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests
{
    public class BaseConnector
    {
        private RestClient _cliet;
        private OAuthToken tokenHandler;
        public BaseConnector(string baseUrl, OAuthToken tokenHandler)
        {
            _cliet = new RestClient(baseUrl);
            this.tokenHandler = tokenHandler;
        }
        public BaseConnector(string baseUrl)
        {
            _cliet = new RestClient(baseUrl);
        }
        public async Task<RequestResult<T>> ProcessRequest<T>(Route route, params string[] parameters)
        {
            RestRequest request = new RestRequest(route.Endpoint, route.Method);
            if (route.AuthRequired)
                request.AddHeader("Authorization", "Bearer " + await tokenHandler.GetTokenAsync());

            if (route.GotFixedParams)
            {
                foreach (var pair in route.FixedParams)
                    request.AddParameter(pair.Key, pair.Value);
            }

            if (route.GotDynamicParams)
            {
                for(int x = 0; x < parameters.Length; x++)
                    request.AddParameter(route.DynamicParams[x], parameters[x]);
            }

            var response = await _cliet.ExecuteAsync<T>(request);
            if (response.IsSuccessful)
                return new RequestResult<T>(true, response.Data);
            else
                return new RequestResult<T>(false, response.Data, JsonSerializer.Deserialize<RequestError>(response.Content));
        }
    }
}
