using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces.Tokens
{
    public interface IIndexProperty
    {
        string GetName();
        object GetValue();
        bool IsHidden();
    }
}
