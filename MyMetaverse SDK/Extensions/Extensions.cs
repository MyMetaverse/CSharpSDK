using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Requests;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMetaverse_SDK.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<JsonObject> ToJson(this IEnumerable<IWalletItem> list) => (list != null) ? list.Select(i => i.ToJson()) : null;
    }
}
