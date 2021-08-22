using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMetaverse_SDK.Meta.Interfaces
{
    public interface IResult<T>
    {
        bool IsSuccessful();
        string GetErrorMessage();
        T Data();
        Exception Exception();
    }
}
