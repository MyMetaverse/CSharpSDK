using MyMetaverse_SDK.Requests.Models.Responses;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface ITokenProperty
    {
        string GetName();
        TokenProperty GetValue();
        bool IsHidden();
    }
}
