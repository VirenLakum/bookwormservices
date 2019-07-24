using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookWorm_Test_1.Pocos
{
    [DataContract]
    public class Language
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "language")]
        public string lang { get; set; }
    }
}