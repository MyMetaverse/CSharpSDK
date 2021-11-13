using MyMetaverse_SDK.Meta.Interfaces;
using MyMetaverse_SDK.Requests.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Requests.Models.Entities
{
    class TokenPropertyEntity : ITokenProperty
    {
        private string _name;
        private TokenProperty _property;
        private bool isHidden;
        public TokenPropertyEntity(string name, TokenProperty property, bool hidden = false)
        {
            _name = name;
            _property = property;
            isHidden = hidden;
        }
        public string GetName() => _name;
        public TokenProperty GetValue() => _property;
        public bool IsHidden() => isHidden;
    }
}
