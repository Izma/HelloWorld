using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorld.Interfaces;

namespace HelloWorld.Helpers
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;
        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }
    }
}