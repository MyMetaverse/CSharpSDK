using MyMetaverse_SDK.Meta.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    public class ItemIndexEntity : IItemIndex
    {
        private string index;
        public ItemIndexEntity(string idx)
        {
            index = idx;
        }

        public string GetIndex() => index;

        public Task UpdateAchievements()
        {
            throw new NotImplementedException();
        }
        public override string ToString() => index;
    }
}
