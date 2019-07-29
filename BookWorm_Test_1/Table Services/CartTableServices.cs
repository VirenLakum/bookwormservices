using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookWorm_Test_1.Pocos;

namespace BookWorm_Test_1.Table_Services
{
    public class CartTableServices
    {
        public static List<Cart> getCartDetail(string userId)
        {
            List<Cart> allCategories = new List<Cart>();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String selectAllStr = "select * from Cart where User_id = @userId;";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cart p = new Cart();
                    p.id = Convert.ToInt32(reader["Id"]);
                    p.user_id = Convert.ToInt32(reader["User_id"]);
                    p.prod_id = Convert.ToInt32(reader["Product_id"]);
                    allCategories.Add(p);
                }
            }

            return allCategories;
        }

        public static Boolean addToCart(string userId, string productId)
        {
            int result = 0;

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String insertStr = "insert into Cart (User_id, Product_id) values(@user_id, @prod_id)";

                SqlCommand cmd = new SqlCommand(insertStr, con);

                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@prod_id", productId);

                con.Open();

                result = cmd.ExecuteNonQuery();
            }

            return result > 0 ? true : false;
        }

        public static Boolean removeFromCart(string userId, string productId)
        {
            int result = 0;

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String insertStr = "delete from Cart where User_id = @user_id and Product_id = @prod_id;";

                SqlCommand cmd = new SqlCommand(insertStr, con);

                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@prod_id", productId);

                con.Open();

                result = cmd.ExecuteNonQuery();
            }

            return result > 0 ? true : false;
        }
    }
}