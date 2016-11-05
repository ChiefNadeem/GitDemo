using System;
using System.Collections.Generic;

namespace Assignment2.Models
{
    public partial class TblUser
    {
        public int Userid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string Type { get; set; }
    }
}
