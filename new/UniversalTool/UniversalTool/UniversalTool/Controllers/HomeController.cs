using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using UniversalTool.Models;
using Microsoft.CSharp;
using UniversalTool.Common;
using Newtonsoft.Json.Linq;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace UniversalTool.Controllers
{
    public class HomeController : Controller
    {
      

        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UniversalTool.Models.User user)
        {
            if (ModelState.IsValid) //If The submitted value is valid
            {
                if (user.IsValid(user.userName, user.password))
                {
                    FormsAuthentication.SetAuthCookie(user.userName, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ConnectDatabase()
        {
            return View();
        }



        public ActionResult CreateTemplate(string _SelectedSchema)
        {

            string response = Convert.ToString(Session["resposne"]);


            var Data = JObject.Parse(response);

            
                Schema SchemaModel = new Schema();
                var value = Data["Schemas"];

                for (int i = 0; i < Data["Schemas"].Count(); i++)
                {
                    var Schemas = value[i];
                    SchemaModel.SchemaList.Add(Schemas["SchemaName"].ToString());
                }


                return View(SchemaModel);
           

        }

        public JsonResult bindTemplate(string _selectedSchema)
        {
            string response = Convert.ToString(Session["resposne"]);


            var Data = JObject.Parse(response);

            Schema SchemaModel = new Schema();

            for (int i = 0; i < Data["Schemas"].Count(); i++)
            {
                if ((Data["Schemas"][i]["SchemaName"]).ToString() == _selectedSchema)
                {
                    for (int j = 0; j < Data["Schemas"][i]["Templates"].Count(); j++)
                    {
                        SchemaModel.TemplateList.Add(String.Format("{0}", Data["Schemas"][i]["Templates"][j]["TemplateName"].ToString()));
                    }
                }
            }
         

            string json = JsonConvert.SerializeObject(SchemaModel.TemplateList).Replace("\\\"", "");

            return Json(json, JsonRequestBehavior.AllowGet);
        }









        public JsonResult ConnectToServer(string database, string user, string password)
        {
            try
            {


                string requestbody = "{";
                requestbody += "\"URL\":\"" + database + "\",\"UserName\":\"" + user + "\",\"Password\":\"" + password + "\"}";

                string response = UniversalTool.Common.Service.connectToDatabase(requestbody).Replace(", ", ",");
                Console.Write(response);
                var data = JObject.Parse(response);


                response = Convert.ToString(data);

                Session["resposne"] = response;

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }
    }
}
