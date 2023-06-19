namespace CleanArchitecture.Application.Models.Identity
{
    public class JwSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public double DurationInMinutes { get; set; }

    }
}
