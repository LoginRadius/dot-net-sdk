using System;

namespace LoginRadiusSDK.API
{
    public interface ILoginRadiusApi
    {
        string ExecuteApi(Guid token);
        string ExecuteRawApi(Guid token);
    }
}
