using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookWorm_Test_1.Pocos;

namespace BookWorm_Test_1.Table_Services
{
    public class LanguageTableServices
    {
        public static List<Language> getAllLanguages()
        {
            List<Language> allLanguages = new List<Language>();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Product_Language";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Language p = new Language();
                    p.id = Convert.ToInt32(reader["Id"]);
                    p.lang = Convert.ToString(reader["Lang_desc"]);
                    allLanguages.Add(p);
                }
            }

            return allLanguages;
        }

        public static Language getLanguageById(string searchId)
        {
            Language result = new Language();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Product_Language where id = @id";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);
                cmd.Parameters.AddWithValue("@id", searchId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.id = Convert.ToInt32(reader["Id"]);
                    result.lang = Convert.ToString(reader["Lang_desc"]);
                }
            }

            return result;
        }
    }
}