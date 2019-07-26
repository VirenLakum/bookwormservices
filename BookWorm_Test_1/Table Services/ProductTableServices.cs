using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BookWorm_Test_1.Table_Services
{
    public class ProductTableServices
    {
        public static bool addProduct(Product p)
        {
            //Console.WriteLine("Got Request");
            //string conStr = ConfigurationManager.ConnectionStrings["bookwormDB"].ConnectionString;

            int result = 0;

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String insertStr = "insert into Products (type_id, language_id, category_id, title, price, selling_price, special_price, special_price_from_date, special_price_to_date, days_of_sale," +
                "short_description, long_description, author, release_date, is_rentable, is_in_library, rent_amount, min_rent_days, publisher, [ image_path])" +
                "values (@typeId, @langID, @catID, @title, @price, @sell, @splPrice, @fromDate, @toDate, @daysOfSale, @shortDesc, @longDesc, @author, @releaseDate, @isRentable, @isInLib, @rentAmount, @minRentDays, @publisher, @imagePath)";

                SqlCommand cmd = new SqlCommand(insertStr, con);

                cmd.Parameters.AddWithValue("@typeId", p.type_id);
                cmd.Parameters.AddWithValue("@langID", p.language_id);
                cmd.Parameters.AddWithValue("@catID", p.category_id);
                cmd.Parameters.AddWithValue("@title", p.title);
                cmd.Parameters.AddWithValue("@price", p.price);
                cmd.Parameters.AddWithValue("@sell", p.sellingPrice);
                cmd.Parameters.AddWithValue("@splPrice", p.specialPrice);
                cmd.Parameters.AddWithValue("@fromDate", DateTime.Parse(p.saleFromDate));
                cmd.Parameters.AddWithValue("@toDate", DateTime.Parse(p.saleToDate));
                cmd.Parameters.AddWithValue("@daysOfSale", p.daysOfSale);
                cmd.Parameters.AddWithValue("@shortDesc", p.shortDescription);
                cmd.Parameters.AddWithValue("@longDesc", p.longDescription);
                cmd.Parameters.AddWithValue("@author", p.authors);
                cmd.Parameters.AddWithValue("@releaseDate", DateTime.Parse(p.releaseDate));
                cmd.Parameters.AddWithValue("@isRentable", p.isRentable);
                cmd.Parameters.AddWithValue("@isInLib", p.isInLibrary);
                cmd.Parameters.AddWithValue("@rentAmount", p.rentAmount);
                cmd.Parameters.AddWithValue("@minRentDays", p.minimumRentDays);
                cmd.Parameters.AddWithValue("@publisher", p.publisher);
                cmd.Parameters.AddWithValue("@imagePath", p.imagePath);

                con.Open();

                result = cmd.ExecuteNonQuery();
            }

            return result > 0 ? true : false;
        }

        public static List<Product> getAllProducts()
        {
            List<Product> allProducts = new List<Product>();

            using (SqlConnection con = GetSqlConnection.getSqlConnection())
            {
                String insertStr = "select * from Products";

                SqlCommand cmd = new SqlCommand(insertStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["Id"]);
                    p.type_id = Convert.ToInt32(reader["type_id"]);
                    p.language_id = Convert.ToInt32(reader["language_id"]);
                    p.category_id = Convert.ToInt32(reader["category_id"]);
                    p.title = Convert.ToString(reader["title"]);
                    p.price = Convert.ToDecimal(reader["price"]);
                    p.sellingPrice = Convert.ToDecimal(reader["selling_price"]);
                    p.specialPrice = Convert.ToDecimal(reader["special_price"]);
                    p.saleFromDate = Convert.ToString(reader["special_price_from_date"]);
                    p.saleToDate = Convert.ToString(reader["special_price_to_date"]);
                    p.daysOfSale = Convert.ToInt32(reader["days_of_sale"]);
                    p.shortDescription = Convert.ToString(reader["short_description"]);
                    p.longDescription = Convert.ToString(reader["long_description"]);
                    p.authors = Convert.ToString(reader["author"]);
                    p.releaseDate = Convert.ToString(reader["release_date"]);
                    p.isRentable = Convert.ToBoolean(reader["is_rentable"]);
                    p.isInLibrary = Convert.ToBoolean(reader["is_in_library"]);
                    p.rentAmount = Convert.ToDecimal(reader["rent_amount"]);
                    p.minimumRentDays = Convert.ToInt32(reader["min_rent_days"]);
                    p.publisher = Convert.ToString(reader["publisher"]);
                    p.imagePath = Convert.ToString(reader[" image_path"]);

                    allProducts.Add(p);
                }
            }

            return allProducts;
        }
    }
}