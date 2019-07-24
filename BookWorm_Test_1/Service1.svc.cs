using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using BookWorm_Test_1.Pocos;
using BookWorm_Test_1.Table_Services;

namespace BookWorm_Test_1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IProductService
    {
        Boolean IProductService.addProduct(Product p)
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


        bool IProductService.addParamter(Parameter param)
        {
            return ParameterTableServices.addParameter(param);
        }


        List<Parameter> IProductService.getAllParameters()
        {
            return ParameterTableServices.getAllParameters();
        }


        Parameter IProductService.getParameterById(string id)
        {
            return ParameterTableServices.getParameterById(id);
        }


        List<TypePoco> IProductService.getAllTypes()
        {
            return TypeTableServices.getAllTypes();
        }


        TypePoco IProductService.getTypeById(string id)
        {
            return TypeTableServices.getTypeById(id);
        }


        List<Category> IProductService.getAllCategories()
        {
            return CategoryTableServices.getAllCategories();
        }


        Category IProductService.getCategoryById(string id)
        {
            return CategoryTableServices.getCategoryById(id);
        }


        List<Language> IProductService.getAllLanguages()
        {
            return LanguageTableServices.getAllLanguages();
        }


        Language IProductService.getLanguageById(string id)
        {
            return LanguageTableServices.getLanguageById(id);
        }


        bool IProductService.addUser(User p)
        {
            return UserTableServices.addUser(p);
        }
    }
}
