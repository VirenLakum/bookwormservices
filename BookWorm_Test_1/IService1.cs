using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BookWorm_Test_1.Pocos;

namespace BookWorm_Test_1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {

        //Product Table APIs
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat=WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, UriTemplate = "/addProduct")]
        Boolean addProduct(Product p);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getAllProducts")]
        List<Product> getAllProducts();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getProductsByCategory/{catId}")]
        List<Product> getProductsByCategory(string catId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getProductsByLanguage/{langId}")]
        List<Product> getProductsByLanguage(string langId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getProductsByType/{typeId}")]
        List<Product> getProductsByType(string typeId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getProductsById/{id}")]
        Product getProductsById(string id);

        //Parameter Table APIs
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/param")]
        Boolean addParamter(Parameter param);

        [OperationContract]
        [WebInvoke(Method="GET", ResponseFormat=WebMessageFormat.Json, UriTemplate="/getAllParameters")]
        List<Parameter> getAllParameters();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getParameterById/{id}")]
        Parameter getParameterById(string id);

        //Type Table APIs
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getAllTypes")]
        List<TypePoco> getAllTypes();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getTypeById/{id}")]
        TypePoco getTypeById(string id);

        //Category Table APIs
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getAllCategories")]
        List<Category> getAllCategories();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getCategoryById/{id}")]
        Category getCategoryById(string id);

        //Language Table APIs
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getAllLanguages")]
        List<Language> getAllLanguages();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getLanguageById/{id}")]
        Language getLanguageById(string id);

        //User Table APIs
        [OperationContract]
        [WebInvoke( Method = "POST", 
                    RequestFormat = WebMessageFormat.Json, 
                    ResponseFormat = WebMessageFormat.Json, 
                    UriTemplate = "/addUser")]
        Boolean addUser(User p);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/authUser")]
        bool authUser(User p);

        //Cart Table Servies
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getCartDetailsFor/{id}")]
        List<Cart> getCartDetails(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/addToCart/{userId}/{productId}")]
        bool addToCart(string userId, string productId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/removeFromCart/{userId}/{productId}")]
        bool removeFromCart(string userId, string productId);

    }
}
