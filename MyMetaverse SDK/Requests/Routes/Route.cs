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
        public string Endpoint => endPoint;

        public bool GotFixedParams { get; private set; }
        private Dictionary<string, string> fixedParams;
        public Dictionary<string, string> FixedParams { get => fixedParams; }

        public bool GotDynamicParams { get; private set; }
        private List<string> dynamicParams;
        public List<string> DynamicParams { get => dynamicParams; }

        public bool GotJsonBody { get; private set; }
        private List<string> jsonBodyObjects;
        public List<string> JsonBodyObjects { get => jsonBodyObjects; }

        public bool AuthRequired { get; private set; }

        public Route(Method method, string endPoint, bool authRequired = true)
        {
            this.method = method;
            this.endPoint = endPoint;
            AuthRequired = authRequired;
        }
        public Route AddFixedParams(string param1,string param2)
        {
            GotFixedParams = true;

            if (fixedParams == null)
                fixedParams = new Dictionary<string, string>();

            fixedParams.Add(param1, param2);
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

        public Route AddJsonBodyObject(string key)
        {
            GotJsonBody = true;
            if (this.jsonBodyObjects == null)
                this.jsonBodyObjects = new List<string>();

            this.jsonBodyObjects.Add(key);
            return this;
        }
    }
}
