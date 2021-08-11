using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IItemIndex
    {
        string GetIndex();
        Task UpdateAchievements();
    }
}
