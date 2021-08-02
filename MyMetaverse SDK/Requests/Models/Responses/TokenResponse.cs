using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Responses
{
    public class TokenResponse
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public long expiresIn { get; set; }
    }
}
