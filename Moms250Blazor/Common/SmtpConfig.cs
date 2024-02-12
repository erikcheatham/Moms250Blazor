namespace Moms250Blazor.Common;

public class SmtpConfig
{
    public string? Server { get; set; }
    public string? User { get; set; }
    public string? Pass { get; set; }
    public int? Port { get; set; }
    public bool? Enabled { get; set; }
    public bool? Debug { get; set; }
    public string? From { get; set; }
    public string? FromDisplayName { get; set; }
    public string? DebugEmailAddress { get; set; }
    public bool? FileSystemMail { get; set; }
    public string? FileSystemFolder { get; set; }
}
