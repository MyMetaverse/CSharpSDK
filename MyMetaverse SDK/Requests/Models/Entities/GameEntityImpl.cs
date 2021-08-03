using MyMetaverse_SDK.Meta.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    class GameEntityImpl : GameEntity
    {
        private MetaConnector connector;
        public GameEntityImpl(MetaConnector connector)
        {
            this.connector = connector;
        }
        private string playerID;
        public string GetPlayerID() => playerID;
       

    }
}
