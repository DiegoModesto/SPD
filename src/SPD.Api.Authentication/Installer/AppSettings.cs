using System;

namespace SPD.Api.Authentication.Installer
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
        public string ConString { get; set; }
        public string DomainName { get; set; }

        public string JwtIssue { get; set; }
        public string JwtAudience { get; set; }
        public string JwtKey { get; set; }
    }
}
