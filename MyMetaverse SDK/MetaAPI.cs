using MyMetaverse_SDK.Meta.Entites;
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
        private OAuthToken tokenHandler;
        private MetaConnector metaConnector;
        public MetaAPI(OAuthToken tokenHandler)
        {
            RoutesHub _routes = new RoutesHub("https://devcloud.mymetaverse.io/adopters");
            routes = _routes;
            this.tokenHandler = tokenHandler;
        }
        public MetaAPI WithCustomRoutes(RouteAdapter _routes)
        {
            routes = _routes;
            return this;
        }
        public MetaAPI Build()
        {
            metaConnector = new MetaConnector(tokenHandler, routes);
            return this;
        }

        public GameEntity BuildPlayer(string playerID)
        {
            return new GameEntityImpl(metaConnector, playerID);
        }
    }
}
