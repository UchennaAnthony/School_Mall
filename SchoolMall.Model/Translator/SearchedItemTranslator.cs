using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class SearchedItemTranslator : TranslatorBase<SearchedItem, SEARCHED_ITEM>
    {
        private ItemDetailTranslator itemDetailTranslator;
        private PersonTranslator personTranslator;
        private SearchedResultTranslator searchedResultTranslator;
        public SearchedItemTranslator()
        {
            itemDetailTranslator = new ItemDetailTranslator();
            personTranslator = new PersonTranslator();
            searchedResultTranslator = new SearchedResultTranslator();
        }
         public override SearchedItem TranslateToModel(SEARCHED_ITEM entity)
        {
            try
            {
                SearchedItem model = null;
                if (entity != null)
                {
                    model = new SearchedItem();
                    model.Id = entity.Searched_Item_Id;
                    model.DateSearched = entity.Date_Searched;
                    model.ItemDetail = itemDetailTranslator.Translate(entity.ITEM_DETAIL);
                    model.Person = personTranslator.Translate(entity.PERSON);
                    model.SearchedResult = searchedResultTranslator.Translate(entity.SEARCH_RESULT);
                }

                return model;
            }
            catch (Exception)
            {                
                throw;
            }
        }
        public override SEARCHED_ITEM TranslateToEntity(SearchedItem model)
        {
            try
            {
                SEARCHED_ITEM entity = null;
                if (model != null)
                {
                    entity = new SEARCHED_ITEM();
                    entity.Searched_Item_Id = model.Id;
                    entity.Date_Searched = model.DateSearched;
                    entity.Item_Id = model.ItemDetail.Id;
                    entity.Person_Id = model.Person.Id;
                    entity.Search_Result_Id = model.SearchedResult.Id;
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
