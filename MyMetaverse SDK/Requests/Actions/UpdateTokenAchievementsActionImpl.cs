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

        private Dictionary<string, TokenPropertyEntity> achievements;
        private Dictionary<string, TokenPropertyEntity> indexAchievements;
        public UpdateTokenAchievementsActionImpl(MetaConnector connector, string tokenID,string tokenIndex)
        {
            this.connector = connector;
            this.tokenID = tokenID;
            this.tokenIndex = tokenIndex;
            achievements = new Dictionary<string, TokenPropertyEntity>();
            indexAchievements = new Dictionary<string, TokenPropertyEntity>();
        }

        //public async Task<IResult<ITokenMetadata>> SaveChanges()
        //{
        //    IResult<ITokenMetadata> result = null;
        //    foreach (var ach in achievements)
        //    {
        //        var bodyObj = new JsonObject();
        //        bodyObj.Add("tokenId", tokenID);
        //        //bodyObj.Add("tokenIndex", tokenIndex);
        //        //bodyObj.Add("propertyName", ach.GetName());
        //        var contObj = new JsonObject();
        //        contObj.Add(ach.Key, ach.Value.props);
        //        bodyObj.Add("content", contObj.ToString());
        //        bodyObj.Add("hiddenProperty", ach.Value.HiddenProp);
        //        result = await connector.ProcessRequest<ITokenMetadata,TokenMetadataEntity>(connector.FindRoute(Routes.Routes.UPDATE_TOKEN_PROPERTY_SCHEMA), endpointParams: new[] { tokenID }, jsonObject: bodyObj);
        //    }
        //    achievements.Clear();

        //    foreach(var iach in indexAchievements)
        //    {
        //        var bodyObj = new JsonObject();
        //        bodyObj.Add("tokenId", tokenID);
        //        bodyObj.Add("tokenIndex", tokenIndex);
        //        bodyObj.Add("propertyName", iach.Key);
        //        bodyObj.Add("content", iach.Value.props.content);
        //        bodyObj.Add("hiddenProperty", iach.Value.HiddenProp);

        //        result = await connector.ProcessRequest<ITokenMetadata, TokenMetadataEntity>(connector.FindRoute(Routes.Routes.UPDATE_INDEX_PROPERTY), endpointParams: new[] { tokenID, tokenIndex, iach.Key }, jsonObject: bodyObj);
        //    }
        //    indexAchievements.Clear();
        //    return result;
        //}

        //public IUpdateTokenAchievementsAction UpdateIndexAchievement(string achName, object value, bool hidden = false)
        //{
        //    if (!indexAchievements.ContainsKey(achName))
        //        indexAchievements.Add(achName, new TokenAchievementEntity(new AchievementProps(value), hidden));
        //    else
        //        indexAchievements[achName] = new TokenAchievementEntity(new AchievementProps(value), hidden);
        //    return this;
        //}
        //public IUpdateTokenAchievementsAction UpdateTokenAchievement(string name, object value, bool hidden = false, AchievementConfig config = null)
        //{
        //    if (!achievements.ContainsKey(name))
        //        achievements.Add(name,  new TokenAchievementEntity(new AchievementProps(value, config),hidden));
        //    else
        //        achievements[name] = new TokenAchievementEntity(new AchievementProps(value, config), hidden);

        //    return this;
        //    //UpdateTokenAchievements(new TokenAchievementEntity().Build(name, value));
        //}
    }
}
