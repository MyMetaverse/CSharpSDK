using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MetaAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private MyMetaverse_SDK.MetaAPI MetaAPI;
        [TestInitialize]
        public async System.Threading.Tasks.Task InitializeAsync()
        {
            MetaAPI = await new MyMetaverse_SDK.MetaAPI().WithCredentials("60a6be577a0ef3d457ba449f", "ZyOJhrdaFPznsHFhhwhLDVEWT0740Tjq").Build();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod1Async()
        {
            var token = MetaAPI.GetToken();
            System.Console.WriteLine($"[{DateTime.Now}]Request Completed, Token: " + token.accessToken);

            token = await MetaAPI.RefreshToken();
            Console.WriteLine($"New Token is: " + token.accessToken);
        }
    }
}
