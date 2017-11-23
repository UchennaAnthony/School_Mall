using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class ItemDetailTranslator : TranslatorBase<ItemDetail, ITEM_DETAIL>
    {
        private ItemCategoryTranslator itemCategoryTranslator;
        private ItemTypeTranslator itemTypeTranslator;
        private UserTranslator userTranslator;
        private LocationTranslator locationTranslator;
        public ItemDetailTranslator()
        {
            itemCategoryTranslator = new ItemCategoryTranslator();
            itemTypeTranslator = new ItemTypeTranslator();
            userTranslator = new UserTranslator();
            locationTranslator = new LocationTranslator();
        }
        public override ItemDetail TranslateToModel(ITEM_DETAIL entity)
        {
            try
            {
                ItemDetail model = null;
                if (entity != null)
                {
                    model = new ItemDetail();
                    model.Id = entity.Item_Id;
                    model.ItemName = entity.Item_Name;
                    model.ItemPath = entity.Uploaded_Image_Url;
                    model.ItemDescription = entity.Item_Description;
                    model.NumberOfItem = entity.Number_Of_Item;
                    model.ItemCategory = itemCategoryTranslator.Translate(entity.ITEM_CATEGORY);
                    model.Location = locationTranslator.Translate(entity.LOCATION);
                    model.AddedBy = userTranslator.Translate(entity.USER);
                    model.TimeUploaded = entity.Time_Uploaded;
                    model.ItemType = itemTypeTranslator.Translate(entity.ITEM_TYPE);
                    model.Price = entity.Price;
                }
                return model;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public override ITEM_DETAIL TranslateToEntity(ItemDetail model)
        {
            try
            {
                ITEM_DETAIL entity = null;
                if (model != null)
                {
                    entity = new ITEM_DETAIL();
                    entity.Item_Id = model.Id;
                    entity.Item_Name = model.ItemName;
                    entity.Item_Description = model.ItemDescription;
                    entity.Uploaded_Image_Url = model.ItemPath;
                    entity.Time_Uploaded = model.TimeUploaded;
                    entity.Location_Id = model.Location.Id;
                    entity.Item_Type_Id = model.ItemType.Id;
                    entity.Added_By = model.AddedBy.Id;
                    entity.Item_Category_Id = model.ItemCategory.Id;
                    entity.Number_Of_Item = model.NumberOfItem;
                    entity.Price = model.Price;
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
