using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class SearchedResultTranslator : TranslatorBase<SearchedResult, SEARCH_RESULT>
    {
        public override SearchedResult TranslateToModel(SEARCH_RESULT entity)
        {
            try
            {
                SearchedResult model = null;
                if (entity != null)
                {
                    model = new SearchedResult();
                    model.Id = entity.Search_Result_Id;
                    model.SearchResultDescription = entity.Search_Result_Description;
                    model.SearchResultName = entity.Search_Result_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override SEARCH_RESULT TranslateToEntity(SearchedResult model)
        {
            try
            {
                SEARCH_RESULT entity = null;
                if (model != null)
                {
                    entity = new SEARCH_RESULT();
                    entity.Search_Result_Id = model.Id;
                    entity.Search_Result_Description = model.SearchResultDescription;
                    entity.Search_Result_Name = model.SearchResultName;
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
