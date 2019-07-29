using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookWorm_Test_1.Pocos
{
    [DataContract]
    public class Cart
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int prod_id { get; set; }

        [DataMember]
        public int user_id { get; set; }
    }
}