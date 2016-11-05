using System;
using System.Collections.Generic;

namespace Assignment2.Models
{
    public partial class TblSubCategory
    {
        public int Scategoryid { get; set; }
        public int Categoryid { get; set; }
        public string ScategoryName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
