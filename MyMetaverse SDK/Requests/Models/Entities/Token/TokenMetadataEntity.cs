using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Actions;
using MyMetaverse_SDK.Requests.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    class TokenMetadataEntity : ITokenMetadata
    {
        private MetaConnector _connector;
        private TokenMetadata _tokenMetadata;
        public TokenMetadataEntity(MetaConnector connector, TokenMetadata tokenMetadata)
        {
            _connector = connector;
            _tokenMetadata = tokenMetadata;
        }

        public string GetTokenID() => _tokenMetadata.tokenId;
        public string GetTokenIndex() => _tokenMetadata.tokenIndex;
        public int GetAmount() => 0;
        public string GetDescription() => _tokenMetadata.description;
        public string GetIamgeUrl() => _tokenMetadata.imageURL;
        public string GetName() => _tokenMetadata.name;
        public IEnumerable<ITokenProperty> GetTokenHiddenProperties() => _tokenMetadata.hiddenProperties.Select(p => new TokenPropertyEntity(p.Key, p.Value,true));
        public IEnumerable<ITokenProperty> GetTokenProperties() => _tokenMetadata.properties.Select(p => new TokenPropertyEntity(p.Key, p.Value));
    }
}
