using System;
using System.Collections.Generic;

namespace Assignment2.Models
{
    public partial class TblCategory
    {
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
