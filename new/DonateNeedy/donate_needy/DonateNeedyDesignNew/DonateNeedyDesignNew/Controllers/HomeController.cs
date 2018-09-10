using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using DonateNeedyDesignNew.Models;
using System.IO;
using DonateNeedyDesignNew.Models.MetaData;
using System.Net.Mail;
using System.Web.Security;

namespace DonateNeedyDesignNew.Controllers
{
    public class HomeController : Controller
    {


        DonateNeedyNewEntities donateNeedy = new DonateNeedyNewEntities();

        ServiceReference1.Service1Client donateneedyservice = new ServiceReference1.Service1Client();

        DateTime date = DateTime.Now;
        DateTime date1 = DateTime.Now;
        DateTime date5 = DateTime.Now;
        DateTime date2 = DateTime.Now;
        int userid;
        #region errorlog
        /// <summary>
        /// This method stores the exception occured in the action result in tblErrorLog
        /// </summary>
        public void errorLog(string message, string type, string pagename)
        {
            try
            {
                writeToLogFile("errorLog - Load Data Binding Begins: " + date, "true");
                int? registrationid = regId();
                donateneedyservice.error(message, type, pagename, registrationid).ToList();
                writeToLogFile("errorLog - Load Data Binding Ends: " + date1 + "\r\n Exception: " + message + "\r\n====================\r\n", "true");
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "errorLog");
            }
        }
        #endregion

        #region track
        /// <summary>
        /// This method store the log file in the local machine at C:\Users\admin\AppData\Roaming\DonateNeedy 
        /// where we can check the time taken for the action result to load
        /// </summary>
        public void writeToLogFile(string Message, string flag)
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\DonateNeedy");

                if (flag.ToLower() == "true")
                {
                    string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).ToString();

                    string path = FilePath + "\\DonateNeedy\\donateneedy.txt";

                    StreamWriter file = new StreamWriter(path, true);
                    file.WriteLine(Message);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "writeToLogFile");
            }

        }

        #endregion

        #region registrationid

        public int? regId()
        {
            writeToLogFile("errorLog Admin - Load Data Binding Begins: " + date, "true");

            int? registrationid;
            if (User.Identity.IsAuthenticated)
            {
                registrationid = getUserID(Convert.ToString(HttpContext.User.Identity.Name));
            }
            else
            {
                registrationid = null;
            }

            writeToLogFile("errorLog Admin - Load Data Binding Ends: " + date1 + "\r\n \r\n====================\r\n", "true");

            return registrationid;


        }

        #endregion

        #region userid
        [Authorize]
        public int getUserID(string userName)
        {
        }
        #endregion

        #region mail
        public void mail(string from, string subject, string body, string email)
        {
            var msg = new MailMessage();
            if (!string.IsNullOrWhiteSpace(from))
            {
                msg.From = new MailAddress(from);
            }
            msg.To.Add(new MailAddress(email));
            msg.To.Add(new MailAddress("sumanth.mani@gmail.com"));
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = HttpUtility.HtmlDecode(body);
            var smtpClient = new SmtpClient();
            smtpClient.Send(msg);
        }

        #endregion

        public ActionResult Index()
        {
            
                return RedirectToAction("Access");

            return View();
        }

        public ActionResult Subscribe()
        {
                return RedirectToAction("Access");
            
                return RedirectToAction("Index");
            return View();
        }

        public ActionResult Search()
        {
            if (Convert.ToString(Session["access"]) != "access")
            {
                return RedirectToAction("Access");
            }
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EventSearch()
        {
            if (Convert.ToString(Session["access"]) != "access")
            {
                return RedirectToAction("Access");
            }
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //public ActionResult CreateFundraisingForm()
        //{
        //    if (Convert.ToString(Session["access"]) != "access")
        //    {
        //        return RedirectToAction("Access");
        //    }
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        public ActionResult DonateForm()
        {
            if (Convert.ToString(Session["access"]) != "access")
            {
                return RedirectToAction("Access");
            }
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public ActionResult home()
        {
            
            return View();
        }


        #region Login and Logout

        #region login
        [HttpGet]
        public ActionResult login(string message, string ReturnUrl)
        {
            return RedirectToAction("Index");

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult login(string username, string password, string ReturnUrl)
        {
            
                return RedirectToAction("Index");
            
        }
        #endregion

        #region social login
        struct Result
        {
            public int usercount;
            public string ID;
            public string ReturnUrl;
        }

        [AllowAnonymous]
        public JsonResult GoogleLogin(string email, string name, string id, string lastname, string locationValue, string ReturnUrl)
        {
            try
            {
                writeToLogFile("GoogleLogin - Load Data Binding Begins: " + date, "true");

                double ID = Convert.ToDouble(id);
                var user = donateNeedy.tblAuthentications.Where(m => m.userName == id && m.tblRegistration.isActive == true && m.tblRegistration.userTypeID == 3).ToList();

                if (Convert.ToInt16(user.Count) != 0)
                {
                    int? reid = user[0].registrationID;
                    var usern = donateNeedy.tblRegistrations.Where(m => m.registrationID == reid && m.isActive == true && m.userTypeID == 3).ToList();
                    FormsAuthentication.SetAuthCookie(usern[0].firstName + "|" + "3" + "|" + id, false);
                }

                Result result = new Result();

                result.usercount = user.Count;
                result.ID = id;
                result.ReturnUrl = ReturnUrl;

                writeToLogFile("GoogleLogin - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                string message = string.Empty;
                errorLog(e.Message.ToString(), e.GetType().ToString(), "GoogleLogin");
                message = "Some thing went wrong. Please try Again..";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }

        [AllowAnonymous]
        public JsonResult FacebookLogin(string name, string id, string email, string locationValue, string ReturnUrl)
        {

            try
            {
                writeToLogFile("FacebookLogin - Load Data Binding Begins: " + date, "true");

                double ID = Convert.ToDouble(id);
                var user = donateNeedy.tblAuthentications.Where(m => m.userName == id && m.tblRegistration.isActive == true && m.tblRegistration.userTypeID == 4).ToList();

                if (Convert.ToInt16(user.Count) != 0)
                {
                    int? reid = user[0].registrationID;
                    var usern = donateNeedy.tblRegistrations.Where(m => m.registrationID == reid && m.isActive == true && m.userTypeID == 4).ToList();
                    FormsAuthentication.SetAuthCookie(usern[0].firstName + "|" + "4" + "|" + id, false);
                }
                Result result = new Result();

                result.usercount = user.Count;
                result.ID = id;
                result.ReturnUrl = ReturnUrl;

                writeToLogFile("FacebookLogin - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                string message = string.Empty;
                errorLog(e.Message.ToString(), e.GetType().ToString(), "FacebookLogin");
                message = "Some thing went wrong. Please try Again..";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Details(string usertypeid, string regid)
        {
            try
            {
                writeToLogFile("Details get - Load Data Binding Begins: " + date, "true");

                if (Convert.ToString(Session["access"]) != "access")
                {
                    return RedirectToAction("Access");
                }
                var Country = donateNeedy.usp_getCountryNames().Select(c => new
                {
                    CountryID = c.countryID,
                    CountryName = c.countryName
                }).ToList();
                ViewBag.Country = new SelectList(Country, "CountryID", "CountryName");

                var Title = donateNeedy.usp_getTitleNames().Select(c => new
                {
                    TitleID = c.titleid,
                    TitleName = c.title
                }).ToList();
                ViewBag.Title1 = new SelectList(Title, "TitleID", "TitleName");
                ViewBag.usertypeid = usertypeid;
                ViewBag.regid = regid;

                writeToLogFile("Details get - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "Details");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Details(clsRegister register, string Country, string State, HttpPostedFileBase File, string city, string Title, string usertypeid, string regid)
        {
            try
            {
                writeToLogFile("Details post - Load Data Binding Begins: " + date, "true");

                var Country1 = donateNeedy.usp_getCountryNames().Select(c => new
                {
                    CountryID = c.countryID,
                    CountryName = c.countryName
                }).ToList();
                ViewBag.Country = new SelectList(Country1, "CountryID", "CountryName");
                var Title1 = donateNeedy.tblTitles.Select(c => new
                {
                    TitleID = c.titleId,
                    TitleName = c.title
                }).ToList();
                ViewBag.Title1 = new SelectList(Title1, "TitleID", "TitleName");
                int countryid = Convert.ToInt32(Country);
                int stateid = Convert.ToInt32(State);
                int cityid = Convert.ToInt32(city);
                int titleid = Convert.ToInt32(Title);
                List<tblState> stateinfo = donateNeedy.tblStates.Where(a => a.countryId == countryid).ToList();
                int Usertypeid = Convert.ToInt32(usertypeid);

                if (File != null && File.ContentLength != 0)
                {
                    string file1 = System.IO.Path.GetFileName(File.FileName);
                    string path1 = System.IO.Path.Combine(Server.MapPath("~/ProfilePictures/"), file1);
                    File.SaveAs(path1);
                    List<usp_CRUDtblRegistation_Result> GetUserByID = donateNeedy.usp_CRUDtblRegistation(0, Usertypeid, countryid, stateid, register.firstName, register.lastName, register.emailID,
                   null, register.Address, cityid, register.Pincode, file1, false, register.PhoneNumber, regid, null, register.middleName, titleid, 1).ToList();

                }
                else
                {
                    List<usp_CRUDtblRegistation_Result> GetUserByID = donateNeedy.usp_CRUDtblRegistation(0, Usertypeid, countryid, stateid, register.firstName, register.lastName, register.emailID,
                    null, register.Address, cityid, register.Pincode, null, false, register.PhoneNumber, regid, null, register.middleName, titleid, 1).ToList();
                }

                var user3 = donateNeedy.tblRegistrations.Where(m => m.emailID == register.emailID && m.isActive == true && m.userTypeID == Usertypeid).ToList();
                if (user3.Count != 0)
                {
                    FormsAuthentication.SetAuthCookie(user3[0].firstName + "|" + "3" + "|" + regid, false);
                }
                else
                {
                    var user4 = donateNeedy.tblRegistrations.Where(m => m.firstName == register.firstName && m.isActive == true && m.userTypeID == Usertypeid).ToList();
                    FormsAuthentication.SetAuthCookie(user4[0].firstName + "|" + "4" + "|" + regid, false);
                }
                writeToLogFile("Details post - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "Details");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region logout
        public ActionResult Logout()
        {
            try
            {
                writeToLogFile("Logout - Load Data Binding Begins: " + date, "true");

                FormsAuthentication.SignOut();
                string str = Request.UrlReferrer.ToString();
                string ext = str.Split(new string[] { "User/" }, StringSplitOptions.None).Last();
                if (!ext.Contains("?"))
                {
                    if (ext.Contains("http"))
                    {
                        writeToLogFile("Logout - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        writeToLogFile("Logout - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                        return RedirectToAction(ext);
                    }
                }
                else
                {
                    if (ext.Contains("http"))
                    {
                        writeToLogFile("Logout - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        writeToLogFile("Logout - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                        string ext1 = str.Split(new string[] { "User/" }, StringSplitOptions.None).Last();
                        string[] ext2 = ext1.Split('?');
                        string[] ext3 = ext2[1].Split('=');
                        return RedirectToAction(ext2[0], new { eventid = ext3[1] });
                    }

                }
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "Logout");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
                return RedirectToAction("Index");
            }
        }
        #endregion

        #endregion

        #region register

        #region register form
        public ActionResult register()
        {
            try
            {
                writeToLogFile("Signup get - Load Data Binding Begins: " + date, "true");

                if (Convert.ToString(Session["access"]) != "access")
                {
                    return RedirectToAction("Access");
                }
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index");
                }

                writeToLogFile("Signup get - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "SignUp-Get");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return base.View();
        }

        [HttpPost]
        public ActionResult register(clsRegister register, string Country, string State, HttpPostedFileBase File, string city, string Title)
        {
            try
            {
                writeToLogFile("signup post - Load Data Binding Begins: " + date, "true");

                int countryid = Convert.ToInt32(Country);
                int stateid = Convert.ToInt32(State);
                int cityid = Convert.ToInt32(city);
                int titleid = Convert.ToInt32(Title);
                List<tblState> stateinfo = donateNeedy.tblStates.Where(a => a.countryId == countryid).ToList();

                var AID = donateNeedy.tblRegistrations.Where(a => a.emailID == register.emailID && a.isActive == true && a.userTypeID == 1).ToList();
                if (Convert.ToInt16(AID.Count) == 0)
                {
                    if (File != null && File.ContentLength != 0)
                    {
                        string file1 = System.IO.Path.GetFileName(File.FileName);
                        string path1 = System.IO.Path.Combine(Server.MapPath("~/Images/ProfilePictures/"), file1);
                        File.SaveAs(path1);
                        List<usp_CRUDtblRegistation_Result> GetUserByID = donateNeedy.usp_CRUDtblRegistation(0, 1, countryid, stateid, register.firstName, register.lastName, register.emailID,
                        register.Password, register.Address, cityid, register.Pincode, file1, false, register.PhoneNumber, register.userName, null, register.middleName, titleid, 1).ToList();

                        string from = "";
                        string subject = "DonateNeedy Registration";
                        string body = "<html>" + "<body>" + "<p style='font-size: 14px; color: #000;'>"
                            + "<p style='font-size: 14px; color: #000;'>" +
                            string.Format("Dear {0} <BR/><BR/> Thank you for registering with us, please click on the link to complete your registration: <a href =\"{1}\">Click Here</a> <br/><br/><br/>Best Regards<br/>From DonateNeedy Team",
                       register.firstName, Url.Action("EmailConfirm", "User", new { Token = GetUserByID[0].registrationID }, Request.Url.Scheme)) +
                       "</p>" + "</body>" + "</html>";

                        mail(from, subject, body, register.emailID);

                        TempData["msg1"] = "We have sent you an e-mail please go through that and confirm your account ";
                    }
                    else
                    {
                        List<usp_CRUDtblRegistation_Result> GetUserByID = donateNeedy.usp_CRUDtblRegistation(0, 1, countryid, stateid, register.firstName, register.lastName, register.emailID,
                        register.Password, register.Address, cityid, register.Pincode, null, false, register.PhoneNumber, register.userName, null, register.middleName, titleid, 1).ToList();


                        string from = "";
                        string subject = "DonateNeedy Registration";
                        string body = "<html>" + "<body>" + "<p style='font-size: 14px; color: #000;'>"
                            + "<p style='font-size: 14px; color: #000;'>" +
                            string.Format("Dear {0} <BR/><BR/> Thank you for registering with us, please click on the link to complete your registration: <a href =\"{1}\">Click Here</a> <br/><br/><br/>Best Regards<br/>From DonateNeedy Team",
                       register.firstName, Url.Action("EmailConfirm", "User", new { Token = GetUserByID[0].registrationID }, Request.Url.Scheme)) +
                       "</p>" + "</body>" + "</html>";

                        mail(from, subject, body, register.emailID);

                        TempData["msg1"] = "We have sent you an e-mail please go through that and confirm your account";
                    }
                }
                else
                {
                    TempData["msg2"] = "Your email is already registered with us";
                    ModelState.Clear();
                }
                writeToLogFile("signup post - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "SignUp");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return View();
        }

        #endregion

        #region emailconfirm
        public ActionResult EmailConfirm(int Token)
        {
            string msg;
            try
            {
                writeToLogFile("EmailConfirm - Load Data Binding Begins: " + date, "true");

                List<usp_GetEmailConfirm_Result> a = donateNeedy.usp_GetEmailConfirm(Token).ToList();
                msg = "Your MailID is Verified. Try login Here..";

                writeToLogFile("EmailConfirm - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "EmailConfirm");
                msg = "Some thing went wrong. Please try Again..";
            }
            return RedirectToAction("Login", new { message = msg });
        }
        #endregion

        #region countries,states,cities
        public ActionResult GetStates(string country_id)
        {
            try
            {
                writeToLogFile("GetStates - Load Data Binding Begins: " + date, "true");

                int countryID1 = Convert.ToInt32(country_id);
                {
                    var contryName = donateNeedy.tblCountries.Where(a => a.countryID == countryID1).Select(a => a.countryName).ToString();
                    List<tblState> stateinfo = donateNeedy.tblStates.Where(a => a.countryId == countryID1).ToList();
                    var stateobj = new List<object>();
                    foreach (var item in stateinfo)
                    {
                        stateobj.Add(new { StateID = item.stateID, StateName = item.stateName });
                    }
                    writeToLogFile("GetStates - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                    return Json(stateobj, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "GetStates");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCountries()
        {
            try
            {
                writeToLogFile("GetCountries - Load Data Binding Begins: " + date, "true");

                List<tblCountry> countryinfo = donateNeedy.tblCountries.Where(a => a.isActive == true).ToList();
                var countryobj = new List<object>();
                foreach (var item in countryinfo)
                {
                    countryobj.Add(new { CountryID = item.countryID, CountryName = item.countryName });
                }
                writeToLogFile("GetCountries - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                return Json(countryobj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "GetCountries");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCity(string state_id)
        {
            try
            {
                writeToLogFile("GetCity - Load Data Binding Begins: " + date, "true");

                int stateID1 = Convert.ToInt32(state_id);
                {
                    var stateName = donateNeedy.tblStates.Where(a=> a.stateID == stateID1).Select(a => a.stateName).ToString();
                    //var stateName = donateNeedy.tblStates.Where(a => a.stateID == stateID1).Select(a => a.stateName).ToString();
                    List<tblCity> cityinfo = donateNeedy.tblCities.Where(a => a.StateID == stateID1).ToList();
                    var cityobj = new List<object>();
                    foreach (var item in cityinfo)
                    {
                        cityobj.Add(new { Cityid = item.CityID, Cityname = item.CityName });
                    }
                    writeToLogFile("GetCity - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                    return Json(cityobj, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "GetCity");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region username availability,email availability
        public ActionResult CheckAvailability(string TitleParam)
        {
            try
            {
                writeToLogFile("CheckAvailability - Load Data Binding Begins: " + date, "true");

                bool Availablle;
                TitleParam = TitleParam.Trim();
                var title = donateNeedy.tblAuthentications.Where(m => m.userName == TitleParam).ToList();
                if (title.Count == 0)
                {
                    Availablle = true;
                }
                else
                {
                    Availablle = false;
                }

                writeToLogFile("CheckAvailability - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                return Json(Availablle, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "CheckAvailability");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckEmailAvailability(string TitleParam)
        {
            try
            {
                writeToLogFile("CheckEmailAvailability - Load Data Binding Begins: " + date, "true");

                bool Availablle;
                TitleParam = TitleParam.Trim();
                var title = donateNeedy.tblRegistrations.Where(m => m.emailID == TitleParam && m.isActive == true && m.userTypeID == 1).ToList();
                if (title.Count == 0)
                {
                    Availablle = true;
                }
                else
                {
                    Availablle = false;
                }

                writeToLogFile("CheckEmailAvailability - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                return Json(Availablle, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "CheckEmailAvailability");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region title
        public ActionResult GetTitle()
        {
            try
            {
                writeToLogFile("GetTitle - Load Data Binding Begins: " + date, "true");

                List<tblTitle> titleinfo = donateNeedy.tblTitles.Where(a => a.isActive == true).ToList();
                var titleobj = new List<object>();
                foreach (var item in titleinfo)
                {
                    titleobj.Add(new { TitleID = item.titleId, TitleName = item.title });
                }

                writeToLogFile("GetTitle - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                return Json(titleobj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "GetTitle");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        #region access
        [HttpGet]
        public ActionResult Access()
        {
            try
            {
                writeToLogFile("Access get - Load Data Binding Begins: " + date, "true");

                Session.Clear();

                writeToLogFile("Access get - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "Access");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Access(string username, string password)
        {
            try
            {
                writeToLogFile("Access post - Load Data Binding Begins: " + date, "true");

                if (username == "donateneedy" && password == "systems")
                {
                    Session["access"] = "access";

                    writeToLogFile("Access post - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg2"] = "Invalid credentials";

                    writeToLogFile("Access post - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                    return View();
                }
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "Access");
                TempData["msg"] = "Some thing went wrong. Please try Again..";
            }
            return View();
        }
        #endregion


        #region createFundraisingForm
        [HttpGet]
        public ActionResult CreateFundraisingForm(string message, int? eventID)
        {
            writeToLogFile("createEvents get - Load Data Binding Begins: " + date, "true");




            if (Convert.ToString(Session["access"]) != "access")
            {
                return RedirectToAction("Access");
            }
            if (User.Identity.IsAuthenticated)
            {

                var userID = getUserID(Convert.ToString(HttpContext.User.Identity.Name));
                ViewBag.userID = userID;
                if (message != null)
                {
                    TempData["msg1"] = message;
                }


                //int eID = Convert.ToInt32(eventID);
                //ViewBag.eID = eventID;
                //var events = donateNeedy.usp_CRUDtblEvent(eventID, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 3).ToList();
                //ViewBag.events = events[0];

                var category1 = donateNeedy.usp_getCategory().Select(c => new
                {
                    categoryId = c.categoryID,
                    categoryname = c.categoryName
                }).ToList();

                ViewBag.category = new SelectList(category1, "categoryId", "categoryName");
              

                var user = donateNeedy.usp_CRUDtblRegistation(userID, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 2).ToList();
                ViewBag.user = user[0];

                //DateTime startDate = DateTime.ParseExact(startdate, "MM/dd/yyyy", null);
                //DateTime endDate = DateTime.ParseExact(enddate, "MM/dd/yyyy", null);

                int stateid1 = Convert.ToInt32(user[0].stateid);
                int cityid1 = Convert.ToInt32(user[0].cityid);
                int countryid1 = Convert.ToInt32(user[0].countryid);

                var Country = donateNeedy.tblCountries.Where(m => m.countryID == countryid1).Select(m => m.countryName).ToList();
                var State = donateNeedy.tblStates.Where(m => m.stateID == stateid1).Select(m => m.stateName).ToList();
                var City = donateNeedy.tblCities.Where(m => m.CityID == cityid1).Select(m => m.CityName).ToList();
                ViewBag.state = State[0];
                ViewBag.city = City[0];
                ViewBag.country = Country[0];

                var FirstName = Convert.ToString(user[0].firstName);
                ViewBag.firstname = FirstName;
                var LastName = Convert.ToString(user[0].lastName);
                ViewBag.lastname = LastName;
                var PhoneNumber = Convert.ToString(user[0].PhoneNumber);
                ViewBag.phonenumber = PhoneNumber;
                var MiddleName = Convert.ToString(user[0].middlename);
                ViewBag.MiddleName = MiddleName;
                var Address = Convert.ToString(user[0].Address);
                ViewBag.Address = Address;
                var Email = Convert.ToString(user[0].emailID);
                ViewBag.email = Email;
                var Photo = user[0].profilePicture;
                ViewBag.photo = Photo;



                //string file1 = System.IO.Path.GetFileName(photo.FileName);
                //string path1 = System.IO.Path.Combine(Server.MapPath("~/images/Events/"), file1);
                //photo.SaveAs(path1);
                //string file2 = null;
                //if (video != null)
                //{
                //    file2 = System.IO.Path.GetFileName(video.FileName);
                //    string path2 = System.IO.Path.Combine(Server.MapPath("~/images/Events/"), file1);
                //    video.SaveAs(path2);
                //}
                //int countryid = Convert.ToInt32(user[0].countryid);
                //int stateid = Convert.ToInt32(user[0].stateid);
                //int cityid = Convert.ToInt32(user[0].cityid);

            }

            else
            {

                var category1 = donateNeedy.usp_getCategory().Select(c => new
                {
                    categoryId = c.categoryID,
                    categoryName = c.categoryName
                }).ToList();
                ViewBag.Category = new SelectList(category1, "categoryId", "categoryName");
                var userID = getUserID(Convert.ToString(HttpContext.User.Identity.Name));
                var user = donateNeedy.usp_CRUDtblRegistation(userID, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 2).ToList();
                ViewBag.user = user[0];

                int stateid = Convert.ToInt32(user[0].stateid);
                int cityid = Convert.ToInt32(user[0].cityid);
                int countryid = Convert.ToInt32(user[0].countryid);
                var country = donateNeedy.tblCountries.Where(m=> m.countryID == countryid).Select(m=> m.countryName).ToList();
                var state = donateNeedy.tblStates.Where(m => m.stateID == stateid).Select(m => m.stateName).ToList();
                var city = donateNeedy.tblCities.Where(m => m.CityID == cityid).Select(m => m.CityName).ToList();

                ViewBag.country = country[0];
                ViewBag.state = state[0];
                ViewBag.city = city[0];
            }
              
                return base.View();
            }

        [HttpPost]
        public ActionResult CreateFundraisingForm(string eventtitle, string organisername, string category, string firstname, string middlename, string lastname, string phonenumber, string email, string state, string city, string address, HttpPostedFileBase photo, HttpPostedFileBase video, string description, string goal, string startdate, string enddate)
        {
            try

            {
                var title_avail = donateNeedy.tblEvents.Where(m => m.Title == eventtitle);
                if(title_avail.Count()==0)
                {
                      userid = getUserID(Convert.ToString(HttpContext.User.Identity.Name));
                    var user = donateNeedy.usp_CRUDtblRegistation(userid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,2).ToList();
                

                    ViewBag.user = user;
                 
                    var category1 = donateNeedy.usp_getCategory().Select(c => new
                    {
                        categoryId = c.categoryID,
                        categoryName = c.categoryName
                    }).ToList();

                    ViewBag.category = new SelectList(category1,"categoryId","categoryName");
                    int categoryid = Convert.ToInt32(category);

                    DateTime startDate = DateTime.ParseExact(startdate, "MM/dd/yyyy", null);
                    DateTime endDate = DateTime.ParseExact(enddate, "MM/dd/yyyy", null);

                    int stateid1 = Convert.ToInt32(user[0].stateid);
                    int cityid1 = Convert.ToInt32(user[0].cityid);
                    int countryid = Convert.ToInt32(user[0].countryid);

                    var Country = donateNeedy.tblCountries.Where(m=>m.countryID==countryid).Select(m=> m.countryName).ToList();
                    var State = donateNeedy.tblStates.Where(m => m.stateID == stateid1).Select(m => m.stateName).ToList();
                    var City = donateNeedy.tblCities.Where(m => m.CityID == cityid1).Select(m => m.CityName).ToList();
                    ViewBag.state = State[0];
                    ViewBag.city = City[0];
                    ViewBag.country = Country[0];
          
                    var FirstName = Convert.ToString(user[0].firstName); 
                    ViewBag.firstname = FirstName;
                    var LastName = Convert.ToString(user[0].lastName);
                    ViewBag.lastname = LastName;
                    var PhoneNumber = Convert.ToString(user[0].PhoneNumber);
                    ViewBag.phonenumber = PhoneNumber;
                    var MiddleName = Convert.ToString(user[0].middlename);
                    ViewBag.MiddleName = middlename;
                    var Address = Convert.ToString(user[0].Address);
                    ViewBag.Address = Address;
                    var Email = Convert.ToString(user[0].emailID);
                    ViewBag.email = Email;
                    var Photo = user[0].profilePicture;
                    ViewBag.photo = Photo;
                   


                    string file1 = System.IO.Path.GetFileName(photo.FileName);
                    string path1 = System.IO.Path.Combine(Server.MapPath("~/images/Events/"), file1);
                    photo.SaveAs(path1);
                    string file2 = null;
                    if (video != null)
                    {
                        file2 = System.IO.Path.GetFileName(video.FileName);
                        string path2 = System.IO.Path.Combine(Server.MapPath("~/images/Events/"), file2);
                        video.SaveAs(path2);
                    }
                   
                    int stateid = Convert.ToInt32(state);
                    int cityid = Convert.ToInt32(city); 

                    List<usp_CRUDtblEventNew_Result> eve = donateNeedy.usp_CRUDtblEventNew(userid, eventtitle, categoryid, description, file1, startDate, endDate, address, false, null, null, null, false, file2,
                           null, organisername, null, null, null,null, phonenumber,email, null, stateid, cityid, null, 2).ToList();
                    TempData["msg1"] = "The event has been created successfully";
                }
               
                return View();
            }
            catch (Exception e)
            {
                errorLog(e.Message.ToString(), e.GetType().ToString(), "createEvents");
                TempData["msg1"] = "Something went wrong. Please try Again";
                return View();
            }
        }

        [HttpPost]
        public ActionResult EnterCharityDetails(string eventtitle, string organisername, string category, string firstname, string middlename, string lastname, string phonenumber, string email, string state, string city, string address, HttpPostedFileBase photo, HttpPostedFileBase video, string description, string goal, string startdate, string enddate)
        {
            try

            {
                var title_avail = donateNeedy.tblEvents.Where(m => m.Title == eventtitle);
                if (title_avail.Count() == 0)
                {
                    userid = getUserID(Convert.ToString(HttpContext.User.Identity.Name));
                    var user = donateNeedy.usp_CRUDtblRegistation(userid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 2).ToList();


                    ViewBag.user = user;

                    var category1 = donateNeedy.usp_getCategory().Select(c => new
                    {
                        categoryId = c.categoryID,
                        categoryName = c.categoryName
                    }).ToList();

                    ViewBag.category = new SelectList(category1, "categoryId", "categoryName");
                    int categoryid = Convert.ToInt32(category);

                    DateTime startDate = DateTime.ParseExact(startdate, "MM/dd/yyyy", null);
                    DateTime endDate = DateTime.ParseExact(enddate, "MM/dd/yyyy", null);

                    int stateid1 = Convert.ToInt32(user[0].stateid);
                    int cityid1 = Convert.ToInt32(user[0].cityid);
                    int countryid = Convert.ToInt32(user[0].countryid);

                    var Country = donateNeedy.tblCountries.Where(m => m.countryID == countryid).Select(m => m.countryName).ToList();
                    var State = donateNeedy.tblStates.Where(m => m.stateID == stateid1).Select(m => m.stateName).ToList();
                    var City = donateNeedy.tblCities.Where(m => m.CityID == cityid1).Select(m => m.CityName).ToList();
                    ViewBag.state = State[0];
                    ViewBag.city = City[0];
                    ViewBag.country = Country[0];
                    


                    string file1 = System.IO.Path.GetFileName(photo.FileName);
                    string path1 = System.IO.Path.Combine(Server.MapPath("~/images/Events/"), file1);
                    photo.SaveAs(path1);
                    string file2 = null;
                    if (video != null)
                    {
                        file2 = System.IO.Path.GetFileName(video.FileName);
                        string path2 = System.IO.Path.Combine(Server.MapPath("~/images/Events/"), file2);
                        video.SaveAs(path2);
                    }

                    int stateid = Convert.ToInt32(state);
                    int cityid = Convert.ToInt32(city);

                    List<usp_CRUDtblEventNew_Result> eve = donateNeedy.usp_CRUDtblEventNew(userid, eventtitle, categoryid, description, file1, startDate, endDate, address, false, null, null, null, false, file2,
                           null, organisername, null, null, null, null, phonenumber, email, null, stateid, cityid, null, 2).ToList();
                    TempData["msg1"] = "The event has been created successfully";
                }

                return View();
            }
            catch (Exception e)
            {
                errorLog(e.Message.ToString(), e.GetType().ToString(), "createEvents");
                TempData["msg1"] = "Something went wrong. Please try Again";
                return View();
            }
        }

        public ActionResult GetCategories()
        {
            try
            {
                writeToLogFile("GetCategories - Load Data Binding Begins: " + date, "true");

                List<tblCategory> countryinfo = donateNeedy.tblCategories.Where(a => a.isActive == true).ToList();
                var categoryobj = new List<object>();
                foreach (var item in countryinfo)
                {
                    categoryobj.Add(new { CategoryId = item.categoryID, CategoryName = item.categoryName });
                }
                writeToLogFile("GetCategories - Load Data Binding Ends: " + date1 + "\r\n====================\r\n", "true");

                return Json(categoryobj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                errorLog(ex.Message.ToString(), ex.GetType().ToString(), "GetCategories");
                TempData["msg"] = "Something went wrong. Please try Again..";
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

    



        public ActionResult checkTitle(string Title)
        {
            var titles= donateNeedy.tblTitles.Where(m=> m.title == Title);
            if (titles.Count() != 0)
                return Json("true", JsonRequestBehavior.AllowGet);

            else
                return Json("false", JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}