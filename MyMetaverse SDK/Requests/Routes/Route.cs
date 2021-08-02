using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Routes
{
    public class Route
    {
        private Method method;
        public Method Method { get => method; }

        private string endPoint;
        public string Endpoint { get => endPoint; }

        public bool GotFixedParams { get; private set; }
        private Dictionary<string, string> fixedParams;
        public Dictionary<string, string> FixedParams { get => fixedParams; }

        public bool GotDynamicParams { get; private set; }
        private List<string> dynamicParams;
        public List<string> DynamicParams { get => dynamicParams; }

        public bool AuthRequired { get; private set; }

        public Route(Method method, string endPoint, bool authRequired = false)
        {
            this.method = method;
            this.endPoint = endPoint;
        }
        public Route AddFixedParams(string param1,string param2)
        {
            GotFixedParams = true;

            if (this.fixedParams == null)
                this.fixedParams = new Dictionary<string, string>();

            this.fixedParams.Add(param1, param2);
            return this;
        }
        public Route AddDynamicParams(string param)
        {
            GotDynamicParams = true;
            if (this.dynamicParams == null)
                this.dynamicParams = new List<string>();

            this.dynamicParams.Add(param);
            return this;
        }
    }
}
