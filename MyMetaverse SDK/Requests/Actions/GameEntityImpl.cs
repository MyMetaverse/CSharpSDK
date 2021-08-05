using MyMetaverse_SDK.Meta.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    class GameEntityImpl : GameEntity
    {
        private MetaConnector connector;
        private string playerID;
        public GameEntityImpl(MetaConnector connector,string playerID)
        {
            this.connector = connector;
            this.playerID = playerID;
        }
        public async Task<PlayerWallet> fetchWallet() => await WalletActionImpl.execute(connector, playerID);
        string GameEntity.getPlayerID() => playerID;
    }
}
