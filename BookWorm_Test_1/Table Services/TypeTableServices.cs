using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookWorm_Test_1.Pocos;

namespace BookWorm_Test_1.Table_Services
{
    public class TypeTableServices
    {
        public static List<TypePoco> getAllTypes()
        {
            List<TypePoco> allTypes = new List<TypePoco>();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Product_Type";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TypePoco p = new TypePoco();
                    p.id = Convert.ToInt32(reader["Id"]);
                    p.typeDesc = Convert.ToString(reader["Type_desc"]);
                    allTypes.Add(p);
                }
            }

            return allTypes;
        }

        public static TypePoco getTypeById(string searchId)
        {
            TypePoco result = new TypePoco();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Product_Type where id = @id";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);
                cmd.Parameters.AddWithValue("@id", searchId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.id = Convert.ToInt32(reader["Id"]);
                    result.typeDesc = Convert.ToString(reader["Type_desc"]);
                }
            }

            return result;
        }
    }
}