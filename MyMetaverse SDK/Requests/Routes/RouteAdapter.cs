using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyMetaverse_SDK.Requests.Routes
{
    public class RouteAdapter
    {
        private string baseUrl;
        public string BaseUrl { get => baseUrl; }
        protected Dictionary<Routes, Route> routes;
        public RouteAdapter(string baseUrl)
        {
            this.baseUrl = baseUrl;
            routes = new Dictionary<Routes, Route>();
        }
        public Route GetRoute(Routes route)
        {
            try
            {
                return routes[route];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
