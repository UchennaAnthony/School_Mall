using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Model
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string ItemCategoryName { get; set; }
        public bool? Activated { get; set; }
    }
}
