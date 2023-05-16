using System.Reflection;

namespace EncurtadorUrl.Api.Shared.Settings
{
    public class AppSettings
    {
        public string PathLog { get; set; }
        public DatabaseSettings Database { get; set; }
        public string EnvironmentName { get; set; }

        public string ApplicationName => Assembly.GetEntryAssembly().GetName().Name;
    }
}
