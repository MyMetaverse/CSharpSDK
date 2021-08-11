using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Token
{
    public interface ITokenHandler
    {
        Task<bool> CreateToken();
        Task<bool> RefreshToken();
        Task<string> GetToken();
    }
}
