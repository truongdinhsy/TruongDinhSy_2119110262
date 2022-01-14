using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Cau1.DAL
{
    class DBConnection
    {
        public DBConnection()
        {
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = SY-PC; Initial Catalog = HR; User Id = sa; Password = sa";
            return conn;
        }
    }

}
