using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class TokenEntity : IToken
    {
        [JsonProperty]
        private string ID;
        [JsonProperty]
        private string index;
        [JsonProperty]
        private int amount;

        private JsonObject requestBody;
        private MetaConnector connector;
        public TokenEntity(MetaConnector connector,string id,string index)
        {
            ID = id;
            this.index = index;
            this.connector = connector;
        }
        public IUpdateTokenAction CreateTokenEditor()
        {
            throw new NotImplementedException();
        }

        public int GetAmount() => amount;

        public string GetID() => ID;

        public string GetIdnex() => index;

        public async Task<IToken> SaveChanges()
        {
            var respond = await connector.ProcessRequest<TokenEntity>(connector.FindRoute(Routes.Routes.UPDATE_TOKEN_DETAILS),endpointParams: new[] { ID }, jsonObject: requestBody);
            if (respond.IsSuccessful)
                return respond.Data;
            else
                throw respond.Exception();
        }

        public void UpdateDescription(string newDescription) => addToRequestBody("description", newDescription);

        public void UpdateName(string newName) => addToRequestBody("name", newName);

        public void UpdateTokenImage(string newImageUrl) => addToRequestBody("TokenImage", newImageUrl);

        private void addToRequestBody(string key,string value)
        {
            if (requestBody == null)
            {
                requestBody = new JsonObject();
                requestBody.Add("tokenId", ID);
                requestBody.Add("tokenIndex", index);
            }

            if (requestBody.ContainsKey(key))
                requestBody[key] = value;
            else
                requestBody.Add(key, value);
        }
    }
}
