using School_Mall.Areas.Member.ViewModel;
using School_Mall.Controllers;
using School_Mall.Models;
using SchoolMall.Business;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace School_Mall.Areas.Member.Controllers
{
    public class SaleController : BaseController
    {
        private SaleViewModel viewModel = null;
        // GET: Member/Sale
        public ActionResult UploadItem()
        {
            try
            {
                viewModel = new SaleViewModel();
                PopulateAllDropDownList();
            }
            catch (Exception ex)
            {
                SetMessage("Error! " + ex.Message, Message.Category.Error);
            }

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult UploadItem(SaleViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {
                    if (Request.Files[0].ContentLength == 0)
                    {
                        SetMessage("Upload a Photo", Message.Category.Error);
                        RetainDropDownState(viewModel);
                        return View();
                    }

                    HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                    string pathForSaving = Server.MapPath("~/Content/Photos");
                    string savedFileName = Path.Combine(pathForSaving, hpf.FileName);
                    //string[] getExtension = hpf.FileName.Split('.');
                    string extension = Path.GetExtension(savedFileName); //"." + getExtension[1];
                    string invalidImage = InvalidFile(Request.Files[0].ContentLength, extension);
                    if (string.IsNullOrEmpty(invalidImage))
                    {
                        hpf.SaveAs(savedFileName);
                    }
                    else
                    {
                        SetMessage(invalidImage, Message.Category.Error);
                        RetainDropDownState(viewModel);
                        return View();
                    }
                    using (TransactionScope scope = new TransactionScope())
                    {
                        ItemDetailLogic itemDetailLogic = new ItemDetailLogic();
                        ItemCategoryLogic itemCategoryLogic = new ItemCategoryLogic();
                        ItemTypeLogic itemTypeLogic = new ItemTypeLogic();
                        UserLogic userLogic = new UserLogic();
                        User user = userLogic.GetModelBy(u => u.User_Name == User.Identity.Name);
                        //ItemCategory itemCategory = new ItemCategory() { Id = 1 };
                        //ItemType itemType = new ItemType(){Id = 1};
                        //Location location = new Location(){Id = 1};
                        //string newItemDetailId = (itemDetailLogic.GetAll().LastOrDefault().Id + 1).ToString();

                        ItemDetail itemDetail = new ItemDetail();
                        itemDetail.ItemName = viewModel.ItemDetail.ItemName;
                        itemDetail.ItemType = viewModel.ItemDetail.ItemType;
                        itemDetail.ItemDescription = viewModel.ItemDetail.ItemDescription;
                        itemDetail.ItemCategory = viewModel.ItemDetail.ItemCategory;
                        itemDetail.ItemPath = "~/Content/Photos" + hpf.FileName;
                        itemDetail.NumberOfItem = viewModel.ItemDetail.NumberOfItem;
                        itemDetail.Price = viewModel.ItemDetail.Price;
                        itemDetail.Location = viewModel.ItemDetail.Location;
                        itemDetail.TimeUploaded = DateTime.Now;
                        itemDetail.AddedBy = user;

                        ItemDetail newItemDetail = itemDetailLogic.Create(itemDetail);
                        scope.Complete();
                        TempData["Msg"] = "Operation Successful";
                        return RedirectToAction("UploadItem");
                    }
                }

            }
            catch (Exception ex)
            {
                SetMessage("Error! " + ex.Message, Message.Category.Error);
            }

            RetainDropDownState(viewModel);
            return View(viewModel);
        }
        private void PopulateAllDropDownList()
        {
            try
            {
                ViewBag.ItemType = viewModel.ItemTypeSelectListItem;
                ViewBag.ItemCategory = viewModel.ItemCategorySelectListItem;
                ViewBag.Location = viewModel.LocationSelectListItem;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string InvalidFile(decimal uploadedFileSize, string fileExtension)
        {
            try
            {
                string message = null;
                decimal oneKiloByte = 1024;
                decimal maximumFileSize = 50 * oneKiloByte;

                decimal actualFileSizeToUpload = Math.Round(uploadedFileSize / oneKiloByte, 1);
                if (InvalidFileType(fileExtension))
                {
                    message = "File type '" + fileExtension + "' is invalid! File type must be any of the following: .jpg, .jpeg, .png or .jif ";
                }
                else if (actualFileSizeToUpload > (maximumFileSize / oneKiloByte))
                {
                    message = "Your file size of " + actualFileSizeToUpload.ToString("0.#") + " Kb is too large, maximum allowed size is " + (maximumFileSize / oneKiloByte) + " Kb";
                }

                return message;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool InvalidFileType(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return false;
                case ".png":
                    return false;
                case ".gif":
                    return false;
                case ".jpeg":
                    return false;
                default:
                    return true;
            }
        }
        private void RetainDropDownState(SaleViewModel viewModel)
        {
            try
            {
                if (viewModel.ItemType != null)
                {
                    ItemTypeLogic itemTypeLogic = new ItemTypeLogic();
                    ViewBag.ItemType = new SelectList(itemTypeLogic.GetAll(), "Id", "ItemTypeName", viewModel.ItemType.Id);  
                }
                else
                {
                    ViewBag.ItemType = new SelectList(new List<Value>(), Utility.ID, Utility.TEXT);
                }
                
                ViewBag.ItemCategory = viewModel.ItemCategorySelectListItem;
                ViewBag.Location = viewModel.LocationSelectListItem;
                }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}