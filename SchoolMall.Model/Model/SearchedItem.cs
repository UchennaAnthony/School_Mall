using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Model
{
    public class SearchedItem
    {
        public long Id { get; set; }
        public ItemDetail ItemDetail { get; set; }
        public Person Person { get; set; }
        public System.DateTime DateSearched { get; set; }
        public SearchedResult SearchedResult { get; set; }
    }
}
