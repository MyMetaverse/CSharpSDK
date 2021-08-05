using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Meta.Entites
{
    public interface GameEntity
    {
        string getPlayerID();

        Task<PlayerWallet> fetchWallet();
    }
}
