using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMetaverse_SDK.Requests.Token;
using System;

namespace MetaAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod1Async()
        {
            OAuthToken tokenHandler = await OAuthToken.CreateAsync("60a6be577a0ef3d457ba449f", "ZyOJhrdaFPznsHFhhwhLDVEWT0740Tjq");
            var MetaAPI = await new MyMetaverse_SDK.MetaAPI().WithTokenHandler(tokenHandler).Build();
            await tokenHandler.RefreshToken();
        }
    }
}
