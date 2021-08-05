using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMetaverse_SDK.Requests.Token;
using System;
using System.Linq;

namespace MetaAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod1Async()
        {
            OAuthToken tokenHandler = await OAuthToken.CreateAsync("60a6be577a0ef3d457ba449f", "ZyOJhrdaFPznsHFhhwhLDVEWT0740Tjq");
            var MetaAPI = new MyMetaverse_SDK.MetaAPI(tokenHandler).Build();


            var player = MetaAPI.BuildPlayer("33");
            var wallet = await player.fetchWallet();
            var mWallet = wallet.getMyMetaverseWallet().ToList();
            foreach(var item in mWallet)
                Console.WriteLine(item.ToString());
            Console.WriteLine("=========================================");
            var enjinWallet = wallet.getEnjinWallet();
            foreach (var item in enjinWallet)
                Console.WriteLine(item.ToString());



            Console.WriteLine(player.getPlayerID());
        }
    }
}
