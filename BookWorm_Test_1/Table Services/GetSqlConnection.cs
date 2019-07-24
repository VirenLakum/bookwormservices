using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BookWorm_Test_1
{
    public class GetSqlConnection
    {
        public static SqlConnection getSqlConnection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["bookwormDB"].ConnectionString;
            return new SqlConnection(conStr);
        }
    }
}