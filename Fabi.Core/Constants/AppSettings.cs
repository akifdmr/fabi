namespace Fabi.Core.Constants;

public class AppSettings
{
       public string? ApiUrl { get; set; }
    public string? AppUrl { get; set; }
    public JWT JWT { get; set; }
}


public class JWT
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double DurationInMinutes { get; set; }
}