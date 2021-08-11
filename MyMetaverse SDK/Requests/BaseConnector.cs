using MyMetaverse_SDK.Requests.Models.Requests;
using MyMetaverse_SDK.Requests.Routes;
using MyMetaverse_SDK.Requests.Token;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests
{
    public class BaseConnector
    {
        private RestClient _client;
        private ITokenHandler tokenHandler;
        public BaseConnector(string baseUrl, ITokenHandler tokenHandler)
        {
            _client = new RestClient(baseUrl);
            _client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.131 Safari/537.36";
            this.tokenHandler = tokenHandler;
        }
        public BaseConnector(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }
        public async Task<RequestResult<T>> ProcessRequest<T>(Route route, string[] endpointParams = null, string[] dynamicParams = null, object[] jsonBody = null, JsonObject jsonObject = null)
        {
            RestRequest request = new RestRequest((endpointParams != null) ? string.Format(route.Endpoint, endpointParams) : route.Endpoint, route.Method);

            if (route.AuthRequired)
                request.AddHeader("Authorization", "Bearer " + await tokenHandler.GetToken());

            if (route.GotFixedParams)
            {
                foreach (var pair in route.FixedParams)
                    request.AddParameter(pair.Key, pair.Value);
            }

            if (route.GotDynamicParams && dynamicParams != null)
            {
                for (int x = 0; x < dynamicParams.Length; x++)
                    request.AddParameter(route.DynamicParams[x], dynamicParams[x]);
            }

            if (route.GotJsonBody && jsonBody != null)
            {
                var jObj = new JsonObject();
                for (int x = 0; x < jsonBody.Length; x++)
                {
                    jObj.Add(route.JsonBodyObjects[x], jsonBody[x]);
                }
                request.AddJsonBody(jObj);
            }
            if (jsonObject != null)
                request.AddJsonBody(jsonObject);

            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
                return new RequestResult<T>(true, JsonConvert.DeserializeObject<T>(response.Content));
            else
            {
                try
                {
                    return new RequestResult<T>(false, JsonConvert.DeserializeObject<RequestError>(response.Content));
                }
                catch (Exception)
                {
                    throw new Exception($"Request to {response.ResponseUri} failed with Status error code: {response.StatusCode}");
                }
            }
        }
    }
}
