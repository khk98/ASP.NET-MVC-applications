using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonateNeedyDesignNew.Models.MetaData
{
    public class clsRegister
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string emailID { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
    }
}