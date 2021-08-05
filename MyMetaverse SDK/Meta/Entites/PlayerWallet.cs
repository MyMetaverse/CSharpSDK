using MyMetaverse_SDK.Requests.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Entites
{
    public interface PlayerWallet
    {
        IEnumerable<WalletItem> getEnjinWallet();
        IEnumerable<WalletItem> getMyMetaverseWallet();
    }
}
