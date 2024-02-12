namespace Moms250Blazor.Data;

public static class ContextSettings
{
    private static string? _DBConnection;
    private static string? _CDNUrl;
    private static string? _WebSiteURL;

    internal static void Configure(string cdnURL, string dbConnection, string websiteURL)
    {
        _CDNUrl = cdnURL;
        _DBConnection = dbConnection;
        _WebSiteURL = websiteURL;
    }

    public static string DBConnection { get => _DBConnection ?? ""; }
    public static string CDNUrl { get => _CDNUrl ?? ""; }
    public static string WebSiteURL { get => _WebSiteURL ?? ""; }
}



//public interface IContextSetting
//{
//    Task<string> GetDBConnectionAsync();
//    Task<string> GetCDNUrlAsync();
//    Task<string> GetWebSiteURLAsync();
//}

//internal sealed class ContextSettings : IContextSetting
//{
//    private string? _DBConnection;
//    private string? _CDNUrl;
//    private string? _WebSiteURL;

//    ContextSettings(string cdnURL, string dbConnection, string websiteURL)
//    {
//        _CDNUrl = cdnURL;
//        _DBConnection = dbConnection;
//        _WebSiteURL = websiteURL;
//    }

//    public Task<string> GetDBConnectionAsync() => Task.Run(() => _DBConnection ?? "");
//    public Task<string> GetCDNUrlAsync() => Task.Run(() => _CDNUrl ?? "");
//    public Task<string> GetWebSiteURLAsync() => Task.Run(() => _WebSiteURL ?? "");
//}
