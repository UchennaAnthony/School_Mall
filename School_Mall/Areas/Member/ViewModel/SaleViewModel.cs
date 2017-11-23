using School_Mall.Models;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Mall.Areas.Member.ViewModel
{
    public class SaleViewModel
    {
        public SaleViewModel()
        {
            LocationSelectListItem = Utility.PopulateLocationSelectListItem();
            ItemTypeSelectListItem = Utility.PopulateItemTypeSelectListItem();
            ItemCategorySelectListItem = Utility.PopulateItemCategorySelectListItem();
            //SearchedResultSelectListItem = Utility.PopulateSearchedResultSelectListItem();
            SearchedItemSelectListItem = Utility.PopulateSearchedItemSelectListItem();
        }
        public Location Location { get; set; }
        public ItemType ItemType { get; set; }
        public ItemDetail ItemDetail { get; set; }
        public User User { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public SearchedItem SearchedItem { get; set; }
        public SearchedResult SearchedResult { get; set; }
        public List<SelectListItem> LocationSelectListItem { get; set; }
        public List<SelectListItem> ItemTypeSelectListItem { get; set; }
        public List<SelectListItem> ItemCategorySelectListItem { get; set; }
        //public List<SelectListItem> SearchedResultSelectListItem { get; set; }
        public List<SelectListItem> SearchedItemSelectListItem { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}