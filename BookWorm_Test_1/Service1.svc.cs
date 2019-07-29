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
            return ProductTableServices.addProduct(p);
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


        bool IProductService.authUser(User p)
        {
            return UserTableServices.authUser(p);
        }


        List<Product> IProductService.getAllProducts()
        {
            return ProductTableServices.getAllProducts();
        }


        List<Product> IProductService.getProductsByCategory(string catId)
        {
            return ProductTableServices.getAllProductsByCategory(catId);
        }


        List<Product> IProductService.getProductsByLanguage(string langId)
        {
            return ProductTableServices.getAllProductsByLanguage(langId);
        }

        List<Product> IProductService.getProductsByType(string typeId)
        {
            return ProductTableServices.getAllProductsByType(typeId);
        }

        Product IProductService.getProductsById(string id)
        {
            return ProductTableServices.getAllProductsById(id);
        }


        List<Cart> IProductService.getCartDetails(string id)
        {
            return CartTableServices.getCartDetail(id);
        }


        bool IProductService.addToCart(string userId, string productId)
        {
            return CartTableServices.addToCart(userId, productId);
        }


        bool IProductService.removeFromCart(string userId, string productId)
        {
            return CartTableServices.removeFromCart(userId, productId);
        }
    }
}
