using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    class UpdateTokenActionImpl : IUpdateTokenAction
    {
        private MetaConnector connector;
        private string tokenID;
        private string tokenIndex;
        private JsonObject requestBody;
        public UpdateTokenActionImpl(MetaConnector connector,string tokenID,string tokenIndex)
        {
            this.connector = connector;
            this.tokenID = tokenID;
            this.tokenIndex = tokenIndex;

        }

        public async Task<IResult<ITokenMetadata>> SaveChanges()
        {
            return await connector.ProcessRequest<ITokenMetadata,TokenMetadataEntity>(connector.FindRoute(Routes.Routes.UPDATE_TOKEN_DETAILS), endpointParams: new[] { tokenID }, jsonObject: requestBody);
        }

        public IUpdateTokenAction UpdateDescription(string newDescription) => addToRequestBody("description", newDescription);

        public IUpdateTokenAction UpdateImage(string newImageUrl) => addToRequestBody("TokenImage", newImageUrl);

        public IUpdateTokenAction UpdateName(string newName) => addToRequestBody("name", newName);

        private UpdateTokenActionImpl addToRequestBody(string key, string value)
        {
            if (requestBody == null)
            {
                requestBody = new JsonObject();
                requestBody.Add("tokenId", tokenID);
                requestBody.Add("tokenIndex", tokenIndex);
            }

            if (requestBody.ContainsKey(key))
                requestBody[key] = value;
            else
                requestBody.Add(key, value);

            return this;
        }
    }
}
