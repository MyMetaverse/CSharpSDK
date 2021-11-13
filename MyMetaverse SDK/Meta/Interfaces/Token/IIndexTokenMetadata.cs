using MyMetaverse_SDK.Meta.Interfaces.Tokens;
using System.Collections.Generic;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IIndexTokenMetadata : IBaseToken
    {
        IEnumerable<IIndexProperty> GetIndexProperties();
        IEnumerable<IIndexProperty> GetIndexHiddenProperties();
    }
}
