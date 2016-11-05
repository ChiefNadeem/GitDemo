using System;
using System.Collections.Generic;

namespace Assignment2.Models
{
    public partial class TblProduct
    {
        public int Productid { get; set; }
        public int Scategoryid { get; set; }
        public int Categoryid { get; set; }
        public string ProductName { get; set; }
        public string ProductDiscription { get; set; }
        public double? ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
