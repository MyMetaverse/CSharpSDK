using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    public class UpdateTokenAchievementsActionImpl : IUpdateTokenAchievementsAction
    {
        private MetaConnector connector;
        private string tokenID;
        private string tokenIndex;

        private List<ITokenAchievement> achievements;
        public UpdateTokenAchievementsActionImpl(MetaConnector connector, string tokenID,string tokenIndex)
        {
            this.connector = connector;
            this.tokenID = tokenID;
            this.tokenIndex = tokenIndex;
            achievements = new List<ITokenAchievement>();
        }

        public async Task<IResult<ITokenMetadata>> SaveChanges()
        {

            IResult<ITokenMetadata> result = null;
            foreach (var ach in achievements)
            {
                var bodyObj = new JsonObject();
                bodyObj.Add("tokenId", tokenID);
                bodyObj.Add("tokenIndex", tokenIndex);
                bodyObj.Add("propertyName", ach.GetName());
                bodyObj.Add("content", ach.GetValue());
                bodyObj.Add("hiddenProperty", false);
                result = await connector.ProcessRequest<ITokenMetadata,TokenMetadataEntity>(connector.FindRoute(Routes.Routes.UPDATE_TOKEN_ACHIEVEMENT), endpointParams: new[] { tokenID, tokenIndex, ach.GetName() }, jsonObject: bodyObj);
            }
            return result;
        }

        public IUpdateTokenAchievementsAction UpdateTokenAchievements(ITokenAchievement tokenAchievement)
        {
            achievements.Add(tokenAchievement);
            return this;
        }

        public IUpdateTokenAchievementsAction UpdateTokenAchievements(string name, object value)  => UpdateTokenAchievements(new TokenAchievementEntity().Build(name, value));
    }
}
