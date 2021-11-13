using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using MyMetaverse_SDK.Requests.Models.Requests;
using MyMetaverse_SDK.Requests.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class GetTokenActionImpl
    {
        public static async Task<IResult<ITokenMetadata>> Create(MetaConnector connector, string tokenId)
        {
           var tokenRequest =  await connector.ProcessRequest<TokenMetadata>(connector.FindRoute(Routes.Routes.GET_TOKEN_METADATA), new[] { tokenId });
            if (tokenRequest.IsSuccessful())
                return new Result<ITokenMetadata>(new TokenMetadataEntity(connector, tokenRequest.Data()), true);
            else
                return new Result<ITokenMetadata>(null, false, new RequestError() { message = tokenRequest.GetErrorMessage() });
        }
        public static async Task<IResult<IIndexTokenMetadata>> Create(MetaConnector connector, string tokenId, string tokenIndex)
        {
            var indexRequest = await connector.ProcessRequest<IndexTokenMetadata>(connector.FindRoute(Routes.Routes.GET_TOKEN_INDEX_METADATA), endpointParams: new[] { tokenId, tokenIndex });

            if (indexRequest.IsSuccessful())
                return new Result<IIndexTokenMetadata>(new IndexTokenMetadataEntity(connector, indexRequest.Data()), true);
            else
                return new Result<IIndexTokenMetadata>(null, false, new RequestError() { message = indexRequest.GetErrorMessage() });
        }
    }
}
