using MyMetaverse_SDK.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IToken
    {
        string GetTokenID();
        //string GetIndex();
        //int GetAmount();
        string GetTokenName();
        string GetTokenDescription();
        string GetTokenImageURL();
       
        void SetConnector(MetaConnector connector);

        //IUpdateTokenAction CreateTokenEditor();
        //IUpdateTokenAchievementsAction CreateTokenAchievementEditor();
    }
    public interface ITokenMetadata : IBaseToken
    {
        IEnumerable<ITokenProperty> GetTokenProperties();
        IEnumerable<ITokenProperty> GetTokenHiddenProperties();
    }
}
