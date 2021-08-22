using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IUpdateTokenAchievementsAction
    {
        IUpdateTokenAchievementsAction UpdateTokenAchievements(ITokenAchievement tokenAchievement);
        IUpdateTokenAchievementsAction UpdateTokenAchievements(string name,object value);
        Task<IResult<ITokenMetadata>> SaveChanges();
    }
}
