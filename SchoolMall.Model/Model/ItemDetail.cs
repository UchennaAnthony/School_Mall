using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Model
{
    public class ItemDetail
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public ItemType ItemType { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public Location Location { get; set; }
        public string ItemPath { get; set; }
        public DateTime TimeUploaded { get; set; }
        public int? NumberOfItem { get; set; }
        public User AddedBy { get; set; }
        public decimal Price { get; set; }
    }
}
