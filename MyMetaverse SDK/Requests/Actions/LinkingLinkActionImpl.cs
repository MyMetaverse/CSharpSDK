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
        public static async Task<IResult<ILinkingLink>> GetLinkingLink(MetaConnector connector, string playerID) => await connector.ProcessRequest<ILinkingLink,LinkingLinkEntity>(connector.FindRoute(Routes.Routes.GET_LINKING_LINK), endpointParams: new[] { playerID });
        public static async Task<IResult<ILinkingLink>> CreateLinkingLink(MetaConnector connector, string playerID, LinkingDetails details) => await connector.ProcessRequest<ILinkingLink,LinkingLinkEntity>(connector.FindRoute(Routes.Routes.CREATE_LINKING_LINK), endpointParams: new[] { playerID }, jsonBody: new[] { details });
    }
}
