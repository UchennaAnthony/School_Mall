using SchoolMall.Business;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Mall.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            SetMessage();
        }
        public static string ImageUrl { get; set; }
        public static string Name { get; set; }
        protected void SetMessage(string message, Message.Category messageType)
        {
            Message msg = new Message(message, (int)messageType);
            TempData["Message"] = msg;
        }

        public void SetMessage()
        {
            try
            {
                UserLogic userLogic = new UserLogic();
                User user = null;
                if (ImageUrl == null)
                {
                    user = userLogic.GetModelBy(u => u.User_Name == Name);
                }

                if (user == null)
                {
                    ViewBag.ImageUrl = ImageUrl;
                }
                else
                {
                    ViewBag.ImageUrl = user.ImageUrl;
                    ImageUrl = user.ImageUrl;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}