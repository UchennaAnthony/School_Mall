using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Model
{
    public class User
    {
        public long Id { get; set; }
        [Required, Display(Name = "Username")]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Role Role { get; set; }
        public string ImageUrl { get; set; }
        public SecurityQuestion SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public Person Person { get; set; }
        public System.DateTime LastLoginDate { get; set; }
    }
}
