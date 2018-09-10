using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversalTool.Models
{
    public class Database
    {
         [Required(ErrorMessage = "Please enter the data server name")]
        public string DataServerName { get; set; }

        [Required(ErrorMessage = "Please enter the user_id")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Please enter the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

    }
}