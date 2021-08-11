using MyMetaverse_SDK.Meta.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMetaverse_SDK.Requests.Actions
{
    class UpdateTokenAction : IUpdateTokenAction
    {
        private MetaConnector connector;
        private string tokenID;
        private string tokenIndex;
        public UpdateTokenAction(MetaConnector connector,string tokenID,string tokenIndex)
        {
            this.connector = connector;

        }
        public Task<IToken> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IUpdateTokenAction UpdateDescription(string description)
        {
            throw new NotImplementedException();
        }

        public IUpdateTokenAction UpdateID(string id)
        {
            throw new NotImplementedException();
        }

        public IUpdateTokenAction UpdateImage(string imageUrl)
        {
            throw new NotImplementedException();
        }

        public IUpdateTokenAction UpdateIndex(string index)
        {
            throw new NotImplementedException();
        }

        public IUpdateTokenAction UpdateName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
