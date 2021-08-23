using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MyMetaverse_SDK;
using System.Linq;
using MyMetaverse_SDK.Requests.Token;
using MyMetaverse_SDK.Meta.Interfaces;
using System.Threading.Tasks;
using MyMetaverse_SDK.Meta.Models;

namespace MetaAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private MyMetaverse_SDK.MetaAPI MetaAPI;
        private IGameEntity ricardo;
        private IGameEntity simon;
        private IGameEntity ahmed;
        [TestInitialize]
        public async Task InitAsync()
        {
            //Building TokenHandler class using Client_id and Client_secret
            TokenHandler th = new TokenHandler("60a6be577a0ef3d457ba449f", "ZyOJhrdaFPznsHFhhwhLDVEWT0740Tjq");
            await th.CreateToken();

            //Buidling New MetaAPI instance using that TokenHandler we created
            MetaAPI = new MyMetaverse_SDK.MetaAPI(th).Build();

            //Building Players Entities
            ricardo = MetaAPI.BuildPlayer("ricardo");
            simon = MetaAPI.BuildPlayer("simon");
            ahmed = MetaAPI.BuildPlayer("ahmed");
        }

        [TestMethod]
        public async Task FetchingWalletsAndEthAddresses()
        {
            //Fetching Players Wallets
            var ricWalletReq = await ricardo.FetchWallet();
            var simWalletReq = await simon.FetchWallet();

            if (ricWalletReq.IsSuccessful())
            {
                var ricEthAddressRequest = await ricardo.FetchEthAddress();

                Console.WriteLine("Ricardo Eth Address: " + (ricEthAddressRequest.IsSuccessful() ? ricEthAddressRequest.Data().GetAddress() : "Failed to retrive eth address"));
                Console.WriteLine("Ricardo Enjin Wallet: ");
                ricWalletReq.Data().GetEnjinWallet().ToList().ForEach(item => { Console.WriteLine("\t" + item.GetName()); });
                Console.WriteLine("Ricardo MyMetaverse Wallet:");
                ricWalletReq.Data().GetMyMetaverseWallet().ToList().ForEach(item => { Console.WriteLine("\t" + item.GetName()); });
            }
            else
                Console.WriteLine(ricWalletReq.GetErrorMessage());

            if (simWalletReq.IsSuccessful())
            {
                var simEthAddressReq = await simon.FetchEthAddress();

                Console.WriteLine("Simon Eth Address: " + (simEthAddressReq.IsSuccessful() ? simEthAddressReq.Data().GetAddress() : "Failed to retrive eth address"));
                Console.WriteLine("Simon Enjin Wallet:");
                simWalletReq.Data().GetEnjinWallet().ToList().ForEach(item => { Console.WriteLine("\t" + item.GetName()); });
                Console.WriteLine("Simon MyMetaverse Wallet:");
                simWalletReq.Data().GetMyMetaverseWallet().ToList().ForEach(item => { Console.WriteLine("\t" + item.GetName()); });
            }
            else
                Console.WriteLine(simWalletReq.GetErrorMessage());

        }

        [TestMethod]
        public async Task GetTradableItemsAndSendTradeRequest()
        {
            //Getting Tradableitems for Two Players
            var ricAndSimTradeableItemsRequest = await ricardo.GetTradeableItems(simon);
            var simAndRicTradeableItemsRequest = await simon.GetTradeableItems(ricardo);


            if (ricAndSimTradeableItemsRequest.IsSuccessful())
            {
                Console.WriteLine("Ricardo Items: ");
                ricAndSimTradeableItemsRequest.Data().GetInitiatorItems().ToList().ForEach(item => { Console.WriteLine("\t" + item.GetTokenId()); });
                Console.WriteLine("Simon Items: ");
                ricAndSimTradeableItemsRequest.Data().GetReceiverItems().ToList().ForEach(item => { Console.WriteLine("\t" + item.GetTokenId()); });
            }
            else
                throw ricAndSimTradeableItemsRequest.Exception();

            if (simAndRicTradeableItemsRequest.IsSuccessful())
            {
                Console.WriteLine("Simon Items: ");
                simAndRicTradeableItemsRequest.Data().GetInitiatorItems().ToList().ForEach(item => { Console.WriteLine("\t" + item.GetTokenId()); });
                Console.WriteLine("Ricardo Items: ");
                simAndRicTradeableItemsRequest.Data().GetReceiverItems().ToList().ForEach(item => { Console.WriteLine("\t" + item.GetTokenId()); });
            }
            else
                throw simAndRicTradeableItemsRequest.Exception();

            //Sending Trade requests
            var ricTradeRequest = await ricardo.SendTradeRequest(simon, ricAndSimTradeableItemsRequest.Data().GetInitiatorItems());
            var simTradeRequest = await simon.SendTradeRequest(ricardo, simAndRicTradeableItemsRequest.Data().GetInitiatorItems(), simAndRicTradeableItemsRequest.Data().GetReceiverItems());

            if (ricTradeRequest.IsSuccessful())
                Console.WriteLine("Ricardo Trade request Init ID: " + ricTradeRequest.Data().GetID());
            else
                throw ricTradeRequest.Exception();

            if (simTradeRequest.IsSuccessful())
                Console.WriteLine("Simon Trade request Rec ID: " + simTradeRequest.Data().GetStatus());
            else
                throw simTradeRequest.Exception();
        }

        [TestMethod]
        public async Task CreateLinkingLink()
        {
            //Creating new linking process, Method takes one parameter of type LinkingDetails that takes Username, ImageUrl and Description as a constructor parameters
            var ricLinkingResult = await ricardo.CreateLinkingLink(new LinkingDetails("Ricardo", "This should be Image URL", "Ricardo Linking process description"));
            var simLinkingResult = await simon.CreateLinkingLink(new LinkingDetails("Simon", "This should be Image URL", "Simon Linking process description"));
            var ahLinkingResult = await ahmed.CreateLinkingLink(new LinkingDetails("Ahmed", "This should be Image URL", "Ahmed Linking process description"));

            if (ricLinkingResult.IsSuccessful())
                Console.WriteLine("Ricardo linking id: " + ricLinkingResult.Data().GetLinkId());
            else
                Console.WriteLine(ricLinkingResult.GetErrorMessage());

            if (simLinkingResult.IsSuccessful())
                Console.WriteLine("Simon linking id: " + simLinkingResult.Data().GetLinkId());
            else
                Console.WriteLine(simLinkingResult.GetErrorMessage());

            if (ahLinkingResult.IsSuccessful())
                Console.WriteLine("Ahmed linking id: " + ahLinkingResult.Data().GetLinkId());
            else
                Console.WriteLine(ahLinkingResult.GetErrorMessage());
        }

        [TestMethod]
        public async Task GetLinkingLink()
        {
            //Getting the most recent Linking process information
            var ricLinkingLink = await ricardo.GetLinkingLink();
            var simLinkingLink = await simon.GetLinkingLink();
            var ahLinkingLink = await ahmed.GetLinkingLink();


            if (ricLinkingLink.IsSuccessful())
                Console.WriteLine("Ricardo linking id: " + ricLinkingLink.Data().GetLinkId());
            else
                Console.WriteLine(ricLinkingLink.GetErrorMessage());

            if (simLinkingLink.IsSuccessful())
                Console.WriteLine("Simon linking id: " + simLinkingLink.Data().GetLinkId());
            else
                Console.WriteLine(simLinkingLink.GetErrorMessage());

            if (ahLinkingLink.IsSuccessful())
                Console.WriteLine("Ahmed linking id: " + ahLinkingLink.Data().GetLinkId());
            else
                Console.WriteLine(ahLinkingLink.GetErrorMessage());
        }


        [TestMethod]
        public async Task TokenManipulating()
        {
            //Building Tokens instances
            var token = MetaAPI.BuildToken("60c6dae7f235842bd82d0759", "1");
            var token1 = MetaAPI.BuildToken("60c6dae7f235842bd82d0759", "2");
            var token2 = MetaAPI.BuildToken("6103116f71bde41c7c7d919a", "New NFT Index");
            var token3 = MetaAPI.BuildToken("60c6dae7f235842bd82d0759", "61031996b893bc2e34d92d4d");
            var tokens = new List<ITokenMetadata>() { token, token1, token2, token3 };

            //var res = await token.CreateTokenEditor().UpdateName("NFT Token Manipulating").UpdateDescription("Token Description Test").SaveChanges();

            //if (!res.IsSuccessful())
            //    Console.WriteLine(res.GetErrorMessage());


            var res2 = await token2.CreateTokenAchievementEditor().UpdateTokenAchievements("NFT", "String Value").SaveChanges();

            //var depo = await ricardo.Deposit(tokens);

        }



    }
}
