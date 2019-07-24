using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using BookWorm_Test_1.Table_Services;

namespace BookWorm_Test_1.Pocos
{
    [DataContract]
    public class Category
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "category")]
        public string category { get; set; }
    }
}