using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    public class DatabaseConnection : IDisposable
    {
        SqlConnection sqlConnection;
        private bool disposed;
        public DatabaseConnection(string connectionString) 
        {
            this.sqlConnection = new SqlConnection(connectionString); 
        }
        public void Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        public void Close()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
        public int ExecuteScalarQuery(string query)
        {
            using (var command = new SqlCommand(query, sqlConnection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public void Dispose()
        {
            if (!disposed)
            {
                sqlConnection?.Dispose();
                disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DatabaseConnection connection = new DatabaseConnection("Shop.sql"))
            {
                connection.Open();
                connection.Close();
            }
        }
    }
}
