using System;

namespace LoginRadius.SDK.API
{
    public interface ILoginRadiusAPI
    {
        string ExecuteAPI(Guid token);
        string ExecuteRawAPI(Guid token);
    }
}
