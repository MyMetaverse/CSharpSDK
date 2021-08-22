using MyMetaverse_SDK.Requests.Models.Entities;
using MyMetaverse_SDK.Requests.Models.Requests;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IPlayerWallet
    {
        IEnumerable<IWalletItem> GetEnjinWallet();
        IEnumerable<IWalletItem> GetMyMetaverseWallet();
        JsonObject ToJson();
    }
}
