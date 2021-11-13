using MyMetaverse_SDK.Meta.Interfaces.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities.Token
{
    public class IndexPropertyEntity : IIndexProperty
    {
        private string _name;
        private object _value;
        private bool isHidden;
        public IndexPropertyEntity(string name, object value, bool hidden = false)
        {
            _name = name;
            _value = value;
            isHidden = hidden;
        }
        public string GetName() => _name;
        public object GetValue() => _value;
        public bool IsHidden() => isHidden;
    }
}
