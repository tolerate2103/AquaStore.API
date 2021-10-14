using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AquaStore.API.DataContext_
{
    public class DataContext : IDisposable
    {
        public string ConnectionString { get; set; }

        public DataContext()
        {
            ConnectionString = @"Data Source=(LocalDB)\\MSSQLLocalDB;database=AquaStoreDb;integrated security=yes";
        }

        public void OpenConnection()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
            }
        }


        public void CloseConnection()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Close();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
