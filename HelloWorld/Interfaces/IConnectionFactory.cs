using System.Data.SqlClient;

namespace HelloWorld.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
