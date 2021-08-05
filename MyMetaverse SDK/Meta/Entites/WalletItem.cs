using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Entites
{
    public interface WalletItem
    {
        string getName();
        string getTokenId();
        bool isNFT();
        List<string> getTokenIndexes();
        int getAmount();
        string getMetadata();
    }
}
