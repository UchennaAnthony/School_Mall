using School_Mall.Areas.Member.ViewModel;
using School_Mall.Controllers;
using SchoolMall.Business;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using System.IO;
using System.Text;
using System.Data.Entity.Validation;
using System.Net.Mail;
using System.Net;

namespace School_Mall.Areas.Member.Controllers
{
    public class RegistrationController : BaseController
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            RegisterViewModel viewModel = new RegisterViewModel();
            try
            {
                PopulateProfileDropDownList(viewModel);
            }
            catch (Exception ex)
            {
                SetMessage("Error: " + ex.Message, Message.Category.Error);
            }

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        // GET: Member/Registration
        public ActionResult SignUp(RegisterViewModel viewModel)
        {
            try
            {
                PersonLogic personLogic = new PersonLogic();
                UserLogic userLogic = new UserLogic();
                if (ModelState.IsValid)
                {
                    User existingUser = userLogic.GetModelsBy(u => u.User_Name == viewModel.User.Username).LastOrDefault();
                    if (existingUser != null)
                    {
                        SetMessage("Username has been used, choose another username! ", Message.Category.Error);
                        PopulateProfileDropDownList(viewModel);
                        return View(viewModel);
                    }
                    using (TransactionScope scope = new TransactionScope())
                    {
                        Person person = new Person();
                        person.FirstName = viewModel.Person.FirstName;
                        person.LastName = viewModel.Person.LastName;
                        person.MobileNumber = viewModel.Person.MobileNumber;
                        person.OtherName = viewModel.Person.OtherName;
                        person.Sex = new Sex() { Id = viewModel.Person.Sex.Id };
                        person.ContactAddress = viewModel.Person.ContactAddress;

                        Person createdPerson = personLogic.Create(person);

                        User user = new User();
                        user.Password = viewModel.User.Password;
                        user.SecurityAnswer = viewModel.User.SecurityAnswer;
                        user.SecurityQuestion = new SecurityQuestion() { Id = viewModel.User.SecurityQuestion.Id };
                        user.Username = viewModel.User.Username;
                        user.Person = createdPerson;
                        user.Email = viewModel.User.Email;
                        user.LastLoginDate = DateTime.Now;
                        user.Role = new Role() { Id = (int)RoleList.User };
                        if(user.ImageUrl != null)
                        {
                            user.ImageUrl = viewModel.User.ImageUrl;
                        }
                        User createdUser = userLogic.Create(user);
                        //string mailMsgBody =
                        //                                "Thank you for registering at Our Mall. Your registration details are as follows:\n Username: " +
                        //                                user.Username + "\n Password: " + user.Password + "\n"
                        //                                + " Login now at UNNmall.com to start selling your Products! ";
                        //string mailAddress = user.Email.Trim();

                        //SendMail(mailMsgBody, mailAddress);

                        scope.Complete();
                    }

                    SetMessage("Your registration was successful, you can now login with your username and password! ", Message.Category.Information);

                    return RedirectToAction("Login", "Account", new { area = "Security" });
                }
            }
            catch (Exception ex)
            {
                SetMessage("Failure! " + ex.Message, Message.Category.Error);
            }

            PopulateProfileDropDownList(viewModel);
            return View(viewModel);
        }

         private void PopulateProfileDropDownList(RegisterViewModel viewModel)
        {
            try
            {
                if (viewModel.User != null)
                {
                    viewModel.User.Password = null;
                }
                if (viewModel.Person != null && viewModel.Person.Sex != null)
                {
                    ViewBag.Sex = new SelectList(viewModel.SexSelectListItem, "Value", "Text", viewModel.Person.Sex.Id);
                }
                else
                {
                    ViewBag.Sex = new SelectList(viewModel.SexSelectListItem, "Value", "Text");
                }
                if (viewModel.User != null && viewModel.User.SecurityQuestion != null)
                {
                    ViewBag.SecurityQuestions = new SelectList(viewModel.SecurityQuestionSelectListItem, "Value", "Text", viewModel.User.SecurityQuestion.Id);
                }
                else
                {
                    ViewBag.SecurityQuestions = new SelectList(viewModel.SecurityQuestionSelectListItem, "Value", "Text");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
         public void SendMail(string msgBody, string emailAddress)
         {
             try
             {
                 SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                 smtpServer.Port = 587;
                 smtpServer.Credentials = new NetworkCredential("UNNmall@gmail.com", "UNNmall2017");
                 smtpServer.EnableSsl = true;
                 smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                 smtpServer.Timeout = 20000;
                 MailMessage eMailMessage = new MailMessage();
                 eMailMessage.From = new MailAddress("UNNmall@gmail.com", "UNNmall");
                 eMailMessage.To.Add(emailAddress);
                 eMailMessage.Subject = "User Registration";
                 eMailMessage.Body = msgBody;

                 smtpServer.Send("UNNmall@gmail.com", emailAddress, "User Registration", msgBody);
             }
             catch (Exception)
             {
                 throw;
             }
         }
         public ActionResult ViewProfile()
         {
             RegisterViewModel viewModel = new RegisterViewModel();
             try
             {
                 UserLogic userLogic = new UserLogic();
                 PersonLogic personLogic = new PersonLogic();

                 string username = User.Identity.Name;
                 User user = userLogic.GetModelBy(p => p.User_Name == username);
                 if (user != null)
                 {
                     Person person = personLogic.GetModelBy(p => p.Person_Id == user.Person.Id);
                     viewModel.User = user;
                     viewModel.Person = person;
                 }
             }
             catch (Exception ex)
             {
                 SetMessage("Error occured! " + ex.Message, Message.Category.Error);
             }
             return View(viewModel);
         }
    }
}