using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class ItemTypeTranslator: TranslatorBase<ItemType, ITEM_TYPE>
    {
         public override ItemType TranslateToModel(ITEM_TYPE entity)
        {
            try
            {
                ItemType model = null;
                if (entity != null)
                {
                    model = new ItemType();
                    model.Id = entity.Item_Type_Id;
                    model.ItemTypeName = entity.Item_Type_Name;
                    model.ItemTypeDescription = entity.Item_Type_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ITEM_TYPE TranslateToEntity(ItemType model)
        {
            try
            {
                ITEM_TYPE entity = null;
                if (model != null)
                {
                    entity = new ITEM_TYPE();
                    entity.Item_Type_Id = model.Id;
                    entity.Item_Type_Name = model.ItemTypeName;
                    entity.Item_Type_Description = model.ItemTypeDescription;
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
