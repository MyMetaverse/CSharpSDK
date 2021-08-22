using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface ITokenMetadata
    {
        string GetID();
        string GetIndex();
        int GetAmount();
        string GetName();
        string GetDescription();
        string GetImageURL();
        object GetProperties();
        object GetHiddenProperties();

        IUpdateTokenAction CreateTokenEditor();
        IUpdateTokenAchievementsAction CreateTokenAchievementEditor();
    }
}
