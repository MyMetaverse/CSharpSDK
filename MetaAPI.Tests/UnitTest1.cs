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
            //CustomRoutes routes = new CustomRoutes("https://cloud.mymetaverse.io/");
            //CustomTokenHandler cth = new CustomTokenHandler("xflood.ow@gmail.com", "iisL0gin!",routes);
            //await cth.CreateToken();
            //var MetaAPI = new MyMetaverse_SDK.MetaAPI(th).Build();

            TokenHandler th = new TokenHandler("60a6be577a0ef3d457ba449f", "ZyOJhrdaFPznsHFhhwhLDVEWT0740Tjq");
            await th.CreateToken();
            var MetaAPI = new MyMetaverse_SDK.MetaAPI(th).Build();

            var ricardo = MetaAPI.BuildPlayer("ricardo");
            var simon = MetaAPI.BuildPlayer("simon");
            var ahmed = MetaAPI.BuildPlayer("ahmed");

            var token = MetaAPI.BuildToken("60c6dae7f235842bd82d0759", "61031996b893bc2e34d92d4d");

            token.UpdateDescription("testing changing description C# SDK");
            token.UpdateName("C# Special Token");
            //token.UpdateTokenImage("https://assets-global.website-files.com/5d56cb37dc00725ec86984e3/6000f0cf6f8a113d4a92f2a4_reg-p-500.png");

            var newToken = await token.SaveChanges();
           


            //var ricAndSimonItems = await ricardo.GetTradeableItems(simon);

            //await ricardo.SendTradeRequest(simon, ricAndSimonItems.GetInitiatorItems(), ricAndSimonItems.GetReceiverItems());

            //var ricardo = MetaAPI.BuildPlayer("ricardo");
            //var wallet = await player.FetchWallet();
            //var recWallet = await ricardo.FetchWallet();
            //await ricardo.GetTradeableItems(simon);
            //await simon.GetTradeableItems(ricardo);
            //await player.GetTradeableItems(ricardo);
            //await player.GetTradeableItems(simon);
            //await ahmed.CreateLinkingLink();



            await ahmed.CreateLinkingLink(new MyMetaverse_SDK.Meta.Models.LinkingDetails("xflood", "https://cloud.mymetaverse.io/assets/image.png", "Hello there, This is Ahmed Abdelbary as xFlooD!"));
            //await player.FetchEthAddress();
            //await player.GetLinkingLink();
            //await simon.GetLinkingLink();


            Console.WriteLine();
        }
    }
}
