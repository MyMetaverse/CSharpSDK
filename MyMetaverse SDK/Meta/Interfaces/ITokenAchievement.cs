using MyMetaverse_SDK.Requests.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface ITokenAchievement
    {
        string GetName();
        object GetValue();
        TokenAchievementConfig Config();
    }
}
