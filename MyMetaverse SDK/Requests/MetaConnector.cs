using MyMetaverse_SDK.Requests.Models.Entities;
using MyMetaverse_SDK.Requests.Models.Responses;
using MyMetaverse_SDK.Requests.Routes;
using MyMetaverse_SDK.Requests.Token;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests
{
    public class MetaConnector : BaseConnector
    {
        private RouteAdapter routeAdapter;
        public MetaConnector(OAuthToken tokenHandler,RouteAdapter routeAdapter) : base(routeAdapter.BaseUrl,tokenHandler)
        {
            this.routeAdapter = routeAdapter;
        }
        public Route FindRoute(Routes.Routes route) => routeAdapter.GetRoute(route);
    }
}
