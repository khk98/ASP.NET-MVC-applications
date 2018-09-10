using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversalTool.Models
{
    public class Schema
    {
        [Required(ErrorMessage = "Please select a Schema")]
        public string Schema_name  { get; set; }

        public string Version { get; set; }

        public string MyProperty { get; set; }
        [Required(ErrorMessage = "Please select a template")]
        public string Template { get; set; }


        public Schema()
        {
            SchemaList = new List<String>();
            TemplateList = new List<String>();
        }

        [DisplayName("Schemas")]
        public List<String> SchemaList
        {
            get;
            set;
        }
        public List<String> TemplateList {
            get;
            set;
        }
    }
}