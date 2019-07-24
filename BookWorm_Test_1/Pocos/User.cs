using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookWorm_Test_1.Pocos
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "password")]
        public string password { get; set; }

        [DataMember(Name = "email")]
        public string email { get; set; }

        [DataMember(Name = "mobile")]
        public string mobile { get; set; }

        [DataMember(Name = "landmark")]
        public string landmark { get; set; }

        [DataMember(Name = "street")]
        public string street { get; set; }

        [DataMember(Name = "city")]
        public string city { get; set; }

        [DataMember(Name = "pincode")]
        public string pincode { get; set; }

        [DataMember(Name = "dob")]
        public string dob { get; set; }

    }
}