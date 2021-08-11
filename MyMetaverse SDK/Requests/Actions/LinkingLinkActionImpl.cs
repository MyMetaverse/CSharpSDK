using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Meta.Models;
using MyMetaverse_SDK.Requests.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class LinkingLinkActionImpl
    {
       public static async Task<LinkingLinkEntity> GetLinkingLink(MetaConnector connector, string playerID)
        {
            var response = await connector.ProcessRequest<LinkingLinkEntity>(connector.FindRoute(Routes.Routes.GET_LINKING_LINK), endpointParams: new[] { playerID });
            if (response.IsSuccessful)
                return response.Data;
            else
                throw response.Exception();
        }
        public static async Task<LinkingLinkEntity> CreateLinkingLink(MetaConnector connector, string playerID, LinkingDetails details)
        {
            var response = await connector.ProcessRequest<LinkingLinkEntity>(connector.FindRoute(Routes.Routes.CREATE_LINKING_LINK), endpointParams: new[] { playerID }, jsonBody: new[] { details });
            if (response.IsSuccessful)
                return response.Data;
            else
                throw response.Exception();
        }
    }
}
