﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace BookWorm_Test_1
{
    [DataContract]
    public class Parameter
    {
        [DataMember(Name="id")]
        public int id {get; set;}


        [DataMember(Name = "value")]
        public string value { get; set; }
    }
}