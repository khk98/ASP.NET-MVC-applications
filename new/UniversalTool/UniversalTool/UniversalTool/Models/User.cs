using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversalTool.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter the username")]
        [Display(Name="E-mail: ")]
        [EmailAddress]
        public string userName { get; set; }
        [Required(ErrorMessage = "Please enter the password")]
        [DataType(DataType.Password)]
        [Display(Name ="Password: ")]
        public string password { get; set; }

        [Display(Name = "Remember me ")]
        public bool RememberMe { get; set; }
        
        public bool IsValid(string _username, string _password)
        {
            if (_username == "admin@gmail.com" && _password == "admin")
                return true;
            else
                return false;
        }
    }
    
}