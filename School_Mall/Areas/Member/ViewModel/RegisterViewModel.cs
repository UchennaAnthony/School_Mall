using School_Mall.Models;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Mall.Areas.Member.ViewModel
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            SexSelectListItem = Utility.PopulateSexSelectListItem();
            SecurityQuestionSelectListItem = Utility.PopulateSecurityQuestionSelectListItem();
        }
        public User User { get; set; }
        public List<SelectListItem> SexSelectListItem { get; set; }
        public Person Person { get; set; }
        public List<SelectListItem> SecurityQuestionSelectListItem { get; set; }
    }
}