using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookWorm_Test_1.Pocos;

namespace BookWorm_Test_1.Table_Services
{
    public class CategoryTableServices
    {
        public static List<Category> getAllCategories()
        {
            List<Category> allCategories = new List<Category>();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Product_Category";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Category p = new Category();
                    p.id = Convert.ToInt32(reader["Id"]);
                    p.category = Convert.ToString(reader["Category_desc"]);
                    allCategories.Add(p);
                }
            }

            return allCategories;
        }

        public static Category getCategoryById(string searchId)
        {
            Category result = new Category();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Product_Category where id = @id";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);
                cmd.Parameters.AddWithValue("@id", searchId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.id = Convert.ToInt32(reader["Id"]);
                    result.category = Convert.ToString(reader["Category_desc"]);
                }
            }

            return result;
        }
    }
}