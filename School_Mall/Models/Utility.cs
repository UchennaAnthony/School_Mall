using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolMall.Business;
using SchoolMall.Model.Model;
using System.Web.UI.WebControls;

namespace School_Mall.Models
{
    public class Utility
    {
        public const string ID = "Id";
        public const string TEXT = "Text";
        public const string NAME = "Name";
        public const string Select = "-- Select --";
        public const string SelectRole = "-- Select Role --";
        public const string SelectSex = "-- Select Sex --";
        public const string SelectItemCategory = "-- Select ItemCategory --";
        public const string SelectItemType = "-- Select ItemType --";
        public static List<SelectListItem> PopulateRoleSelectListItem()
        {
            try
            {
                RoleLogic roleLogic = new RoleLogic();
                List<Role> roles = roleLogic.GetAll();
                if (roles == null || roles.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> roleList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectRole;
                roleList.Add(list);
                foreach (Role role in roles)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = role.Id.ToString();
                    selectList.Text = role.RoleName;

                    roleList.Add(selectList);
                }

                return roleList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateSexSelectListItem()
        {
            try
            {
                SexLogic sexLogic = new SexLogic();
                List<Sex> Sexes = sexLogic.GetAll();
                if (Sexes == null || Sexes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> sexList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectSex;
                sexList.Add(list);
                foreach (Sex sex in Sexes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = sex.Id.ToString();
                    selectList.Text = sex.SexName;

                    sexList.Add(selectList);
                }

                return sexList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateItemCategorySelectListItem()
        {
            try
            {
                ItemCategoryLogic itemCategoryLogic = new ItemCategoryLogic();
                List<ItemCategory> itemCategories = itemCategoryLogic.GetAll();

                if (itemCategories == null && itemCategories.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> itemCategoryList = new List<SelectListItem>();
                if (itemCategories != null && itemCategories.Count > 0)
                {
                    SelectListItem list = new SelectListItem();
                    list.Value = "";
                    list.Text = Select;
                    itemCategoryList.Add(list);

                    foreach (ItemCategory itemCategory in itemCategories)
                    {
                        SelectListItem selectList = new SelectListItem();
                        selectList.Value = itemCategory.Id.ToString();
                        selectList.Text = itemCategory.ItemCategoryName;

                        itemCategoryList.Add(selectList);
                    }
                }

                return itemCategoryList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateSecurityQuestionSelectListItem()
        {
            try
            {
                SecurityQuestionLogic securityQuestionLogic = new SecurityQuestionLogic();
                List<SecurityQuestion> securityQuestions = securityQuestionLogic.GetAll();
                if (securityQuestions == null || securityQuestions.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> securityQuestionList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                securityQuestionList.Add(list);
                foreach (SecurityQuestion securityQuestion in securityQuestions)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = securityQuestion.Id.ToString();
                    selectList.Text = securityQuestion.Question;

                    securityQuestionList.Add(selectList);
                }

                return securityQuestionList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateItemTypeSelectListItem()
        {
            try
            {
                ItemTypeLogic itemTypeLogic = new ItemTypeLogic();
                List<ItemType> itemTypes = itemTypeLogic.GetAll();

                if (itemTypes == null && itemTypes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> itemTypeList = new List<SelectListItem>();
                if (itemTypes != null && itemTypes.Count > 0)
                {
                    SelectListItem list = new SelectListItem();
                    list.Value = "";
                    list.Text = Select;
                    itemTypeList.Add(list);

                    foreach (ItemType itemType in itemTypes)
                    {
                        SelectListItem selectList = new SelectListItem();
                        selectList.Value = itemType.Id.ToString();
                        selectList.Text = itemType.ItemTypeName;

                        itemTypeList.Add(selectList);
                    }
                }

                return itemTypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateLocationSelectListItem()
        {
            try
            {
                LocationLogic locationLogic = new LocationLogic();
                List<Location> locations = locationLogic.GetAll();

                if (locations == null && locations.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> locationList = new List<SelectListItem>();
                if (locations != null && locations.Count > 0)
                {
                    SelectListItem list = new SelectListItem();
                    list.Value = "";
                    list.Text = Select;
                    locationList.Add(list);

                    foreach (Location location in locations)
                    {
                        SelectListItem selectList = new SelectListItem();
                        selectList.Value = location.Id.ToString();
                        selectList.Text = location.LocationName;

                        locationList.Add(selectList);
                    }
                }

                return locationList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateSearchedItemSelectListItem()
        {
            try
            {
                SearchedItemLogic searchedItemLogic = new SearchedItemLogic();
                List<SearchedItem> searcheditems = searchedItemLogic.GetAll();

                if (searcheditems == null && searcheditems.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> searchedItemList = new List<SelectListItem>();
                if (searcheditems != null && searcheditems.Count > 0)
                {
                    SelectListItem list = new SelectListItem();
                    list.Value = "";
                    list.Text = Select;
                    searchedItemList.Add(list);

                    foreach (SearchedItem searchedItem in searcheditems)
                    {
                        SelectListItem selectList = new SelectListItem();
                        selectList.Value = searchedItem.Id.ToString();
                        //selectList.Text = searchedItem.searchedItemName;

                        searchedItemList.Add(selectList);
                    }
                }

                return searchedItemList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void BindDropdownItem<T>(DropDownList dropDownList, T items, string dataValueField, string dataTextField)
        {
            dropDownList.Items.Clear();

            dropDownList.DataValueField = dataValueField;
            dropDownList.DataTextField = dataTextField;


            dropDownList.DataSource = items;
            dropDownList.DataBind();
        }
        public static List<Value> CreateNumberListFrom(int startValue, int endValue)
        {
            List<Value> values = new List<Value>();

            try
            {
                for (int i = startValue; i <= endValue; i++)
                {
                    Value value = new Value();
                    value.Id = i;
                    value.Name = i.ToString();
                    values.Add(value);
                }

                //values.Insert(0, new Value() { Id = 0, Name = Select });
                return values;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}