using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IEthAddress
    {
        bool IsLinked();
        string GetAddress();
    }
}
