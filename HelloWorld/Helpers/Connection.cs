using System.Configuration;

namespace HelloWorld.Helpers
{
    public class Connection
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["helloworld"].ConnectionString;
            }
        }

    }
}