using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SchoolMall.Model.Model
{
    public class Person
    {
        private string fullName;
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string FullName
        {
            get { return LastName + " " + FirstName + " " + OtherName; }
            set { fullName = value; }
        }
        [Required, Display(Name = "Phone Number"), DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        public string ContactAddress { get; set; }
        public Sex Sex { get; set; }
    }
}
