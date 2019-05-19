using System.Configuration;

namespace Interview
{
    public static class ConfigHelper
    {
        public static class ConnectionStrings
        {
            public static string Demo => Get("Demo");

            private static string Get(string key) =>
                ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}