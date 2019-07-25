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
    }
}
