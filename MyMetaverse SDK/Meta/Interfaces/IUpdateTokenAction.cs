using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IUpdateTokenAction
    {
        IUpdateTokenAction UpdateID(string id);
        IUpdateTokenAction UpdateIndex(string index);
        IUpdateTokenAction UpdateName(string name);
        IUpdateTokenAction UpdateDescription(string description);
        IUpdateTokenAction UpdateImage(string imageUrl);
        Task<IToken> SaveChanges();
    }
}
