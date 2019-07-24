using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookWorm_Test_1
{
    [DataContract]
    public class Product
    {
        [DataMember(Name="id")]
        public int id { get; set; }

        [DataMember(Name = "type_id")]
        public int type_id { get; set; }

        [DataMember(Name = "language_id")]
        public int language_id { get; set; }

        [DataMember(Name = "category_id")]
        public int category_id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "price")]
        public Decimal price { get; set; }

        [DataMember(Name = "sellingPrice")]
        public Decimal sellingPrice { get; set; }

        [DataMember(Name = "specialPrice")]
        public Decimal specialPrice { get; set; }

        [DataMember(Name = "saleFromDate")]
        public string saleFromDate { get; set; }

        [DataMember(Name = "saleToDate")]
        public string saleToDate { get; set; }

        [DataMember(Name = "daysOfSale")]
        public int daysOfSale { get; set; }

        [DataMember(Name = "shortDescription")]
        public string shortDescription { get; set; }

        [DataMember(Name = "longDescription")]
        public string longDescription { get; set; }

        [DataMember(Name = "authors")]
        public string authors { get; set; }

        [DataMember(Name = "releaseDate")]
        public string releaseDate { get; set; }

        [DataMember(Name = "isRentable")]
        public Boolean isRentable { get; set; }

        [DataMember(Name = "isInLibrary")]
        public Boolean isInLibrary { get; set; }

        [DataMember(Name = "rentAmount")]
        public Decimal rentAmount { get; set; }

        [DataMember(Name = "minimumRentDays")]
        public int minimumRentDays { get; set; }

        [DataMember(Name = "publisher")]
        public string publisher { get; set; }

        [DataMember(Name = "imagePath")]
        public string imagePath { get; set; }

    }
}