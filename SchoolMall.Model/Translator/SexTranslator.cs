using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class SexTranslator : TranslatorBase<Sex, SEX>
    {
        public override Sex TranslateToModel(SEX entity)
        {
            try
            {
                Sex model = null;
                if (entity != null)
                {
                    model = new Sex();
                    model.Activated = entity.Activated;
                    model.Id = entity.Sex_Id;
                    model.SexName = entity.Sex_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override SEX TranslateToEntity(Sex model)
        {
            try
            {
                SEX entity = null;
                if (model != null)
                {
                    entity = new SEX();
                    entity.Activated = model.Activated;
                    entity.Sex_Id = model.Id;
                    entity.Sex_Name = model.SexName;
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
