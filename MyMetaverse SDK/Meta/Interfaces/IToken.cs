using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IToken
    {
        string GetID();
        string GetIdnex();
        int GetAmount();
        void UpdateName(string newName);
        void UpdateDescription(string newDescription);
        void UpdateTokenImage(string newImageUrl);
        Task<IToken> SaveChanges();
    }
}
