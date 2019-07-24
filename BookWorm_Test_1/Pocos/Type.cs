using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookWorm_Test_1.Pocos
{
    [DataContract]
    public class TypePoco
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "value")]
        public string typeDesc { get; set; }
    }
}