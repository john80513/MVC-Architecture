using System.Configuration;

namespace AP.Models.Helper
{
    public class DbHelper
    {
        public static string GetAPAPDBConnection()
        {
            return ConfigurationManager.ConnectionStrings["APAPDB"].ToString();
        }

        public static string GetAPFETDBConnection()
        {
            return ConfigurationManager.ConnectionStrings["APFETDB"].ToString();
        }

        public static string GetAPPHODBConnection()
        {
            return ConfigurationManager.ConnectionStrings["APPHODB"].ToString();
        }
    }
}
