using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookWorm_Test_1.Pocos;

namespace BookWorm_Test_1.Table_Services
{
    public class UserTableServices
    {
        public static bool addUser(User user)
        {
            int result = 0;

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                string str = "insert into Users (name, password, email, mobile, street, city, landmark, pincode, dob)";
                str += "values (@name, @password, @email, @mob, @street, @city, @landmark, @pincode, @dob);";

                SqlCommand cmd = new SqlCommand(str, con);

                cmd.Parameters.AddWithValue("@name", user.name);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@mob", user.mobile);
                cmd.Parameters.AddWithValue("@street", user.street);
                cmd.Parameters.AddWithValue("@city", user.city);
                cmd.Parameters.AddWithValue("@landmark", user.landmark);
                cmd.Parameters.AddWithValue("@pincode", user.pincode);
                cmd.Parameters.AddWithValue("@dob", user.dob);
                con.Open();

                result = cmd.ExecuteNonQuery();
            }
            return result > 0 ? true : false;
        }
    }
}