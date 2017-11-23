using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class ItemCategoryTranslator : TranslatorBase<ItemCategory, ITEM_CATEGORY>
    {
        public override ItemCategory TranslateToModel(ITEM_CATEGORY entity)
        {
            try
            {
                ItemCategory model = null;
                if (entity != null)
                {
                    model = new ItemCategory();
                    model.Id = entity.Item_Categroy_Id;
                    model.Activated = entity.Activated;
                    model.ItemCategoryName = entity.Item_Category_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override ITEM_CATEGORY TranslateToEntity(ItemCategory model)
        {
            try
            {
                ITEM_CATEGORY entity = null;
                if (model != null)
                {
                    entity = new ITEM_CATEGORY();
                    entity.Item_Categroy_Id = model.Id;
                    entity.Activated = model.Activated;
                    entity.Item_Category_Name = model.ItemCategoryName;
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
