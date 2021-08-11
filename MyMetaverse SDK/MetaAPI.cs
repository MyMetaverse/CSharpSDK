using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests;
using MyMetaverse_SDK.Requests.Actions;
using MyMetaverse_SDK.Requests.Models.Entities;
using MyMetaverse_SDK.Requests.Models.Responses;
using MyMetaverse_SDK.Requests.Routes;
using MyMetaverse_SDK.Requests.Token;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK
{
    public class MetaAPI
    {
        private RouteAdapter routes;
        private ITokenHandler tokenHandler;
        private MetaConnector metaConnector;

        ///<summary>MetaAPI Constructor takes <typeparamref name="OAuthToken"/> 
        ///as a parameter to handle authentication token
        ///</summary>
        ///<remarks> 
        ///Call <typeparamref name="Build"/> method after initiating the constructor
        ///</remarks>
        public MetaAPI(ITokenHandler tokenHandler)
        {
            RoutesHub _routes = new RoutesHub("https://devcloud.mymetaverse.io/adopters");
            routes = _routes;
            this.tokenHandler = tokenHandler;
        }

        ///<summary>
        ///Use this method to pass custom routing to the MetaAPI
        ///</summary>
        ///<remarks> 
        ///Call <typeparamref name="Build"/> method after initiating the constructor
        ///</remarks>
        public MetaAPI WithCustomRoutes(RouteAdapter _routes)
        {
            routes = _routes;
            return this;
        }
        ///<summary>Build MetaAPI instance</summary>
        public MetaAPI Build()
        {
            metaConnector = new MetaConnector(tokenHandler, routes);
            return this;
        }
        ///<summary>Build a new instance of <typeparamref name="GameEntity"/></summary>
        ///<returns><typeparamref name="GameEntity"/></returns>
        public IGameEntity BuildPlayer(string playerID)
        {
            return new GameEntityImpl(metaConnector, playerID);
        }
        public IToken BuildToken(string id,string index = null)
        {
            return new TokenEntity(metaConnector,id, index);
        }
    }
}
