using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BookWorm_Test_1
{
    public class ParameterTableServices
    {
        public static Boolean addParameter(Parameter param)
        {
            int result = 0;

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String insertStr = "insert into Product_Parameter values(@value)";

                SqlCommand cmd = new SqlCommand(insertStr, con);

                cmd.Parameters.AddWithValue("@value", param.value);

                con.Open();

                result = cmd.ExecuteNonQuery();
            }

            return result > 0 ? true : false;
        }

        public static List<Parameter> getAllParameters()
        {
            List<Parameter> allParameter = new List<Parameter>();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Product_Parameter";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Parameter p = new Parameter();
                    p.id = Convert.ToInt32(reader["Id"]);
                    p.value = Convert.ToString(reader["param_desc"]);
                    allParameter.Add(p);
                }
            }

            return allParameter;
        }

        public static Parameter getParameterById(string searchId)
        {
            Parameter result = new Parameter();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Product_Parameter where id = @id";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);
                cmd.Parameters.AddWithValue("@id", searchId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.id = Convert.ToInt32(reader["Id"]);
                    result.value = Convert.ToString(reader["param_desc"]);
                }
            }

            return result;
        }
    }
}