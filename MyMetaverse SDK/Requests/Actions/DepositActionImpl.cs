using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class DepositActionImpl<T>
    {
        private static JsonObject requestBody;
        public static async Task<IResult<T>> Execute(MetaConnector connector, string playerID, IEnumerable<ITokenMetadata> tokens)
        {
            convertTokens(tokens);
            requestBody.Add("PlayerID", playerID);
            return await connector.ProcessRequest<T>(connector.FindRoute(Routes.Routes.DEPOSIT), jsonObject: requestBody);
        }
        private static void convertTokens(IEnumerable<ITokenMetadata> tokens)
        {
            requestBody = new JsonObject();
            List<JsonObject> objects = new List<JsonObject>();
            foreach(var token in tokens)
            {
                JsonObject tokenObject = new JsonObject();
                tokenObject.Add("token_id", token.GetID());
                tokenObject.Add("token_index", token.GetIndex());
                tokenObject.Add("value", token.GetAmount().ToString());
                objects.Add(tokenObject);
            }
            requestBody.Add("Items", objects);
        }
    }
}
