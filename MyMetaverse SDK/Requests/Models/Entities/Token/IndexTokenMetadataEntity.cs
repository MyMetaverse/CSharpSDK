using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Meta.Interfaces.Tokens;
using MyMetaverse_SDK.Requests.Models.Entities.Token;
using MyMetaverse_SDK.Requests.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class IndexTokenMetadataEntity : IIndexTokenMetadata
    {
        private MetaConnector _connector;
        private IndexTokenMetadata _index;

        public IndexTokenMetadataEntity(MetaConnector connector, IndexTokenMetadata index)
        {
            _connector = connector;
            _index = index;
        }
        public string GetName() => _index.name;

        public string GetTokenID() => _index.tokenId;

        public string GetTokenIndex() => _index.tokenIndex;
        public int GetAmount() => 0;

        public string GetDescription() => _index.description;

        public string GetIamgeUrl() => _index.imageURL;

        public IEnumerable<IIndexProperty> GetIndexHiddenProperties() => _index.properties.Select(p => new IndexPropertyEntity(p.Key, p.Value));

        public IEnumerable<IIndexProperty> GetIndexProperties() => _index.hiddenProperties.Select(hp => new IndexPropertyEntity(hp.Key, hp.Value, true));
       
    }
}
