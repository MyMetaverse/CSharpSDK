using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IUpdateTokenAction
    {
        //string GetTokenID();
        //string GetTokenIndex();
        IUpdateTokenAction UpdateDescription(string newDescription);
        IUpdateTokenAction UpdateName(string newName);
        IUpdateTokenAction UpdateImage(string newImageUrl);
        Task<IResult<ITokenMetadata>> SaveChanges();
    }
}
