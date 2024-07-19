using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_420_DA3_AS_Part2.DAL
{
    internal class UtilityDB
    {

        public static SqlConnection ConnectDB()
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn.Open();      
            return conn;
        }
    }
}
