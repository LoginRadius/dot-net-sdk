using System;

namespace LoginRadiusSDK.V2.Api
{
    public interface ILoginRadiusApi
    {
        string ExecuteApi(Guid token);
        string ExecuteRawApi(Guid token);
    }
}