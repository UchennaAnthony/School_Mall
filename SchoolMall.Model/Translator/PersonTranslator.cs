using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class PersonTranslator : TranslatorBase<Person, PERSON>
    {
        private SexTranslator sexTranslator;
        public PersonTranslator()
        {
            sexTranslator = new SexTranslator();
        }
        public override Person TranslateToModel(PERSON entity)
        {
            try
            {
                Person model = null;
                if (entity != null)
                {
                    model = new Person();
                    model.Id = entity.Person_Id;
                    model.ContactAddress = entity.Contact_Address;
                    model.FirstName = entity.First_Name;
                    model.LastName = entity.Last_Name;
                    model.MobileNumber = entity.Mobile_Number;
                    model.OtherName = entity.Other_Name;
                    model.Sex = sexTranslator.Translate(entity.SEX);
                    }

                return model;
            }
            catch (Exception)
            {                
                throw;
            }
        }
        public override PERSON TranslateToEntity(Person model)
        {
            try
            {
                PERSON entity = null;
                if (model != null)
                {
                    entity = new PERSON();
                    entity.Person_Id = model.Id;
                    entity.Contact_Address = model.ContactAddress;
                    entity.First_Name = model.FirstName;
                    entity.Last_Name = model.LastName;
                    entity.Other_Name = model.OtherName;
                    entity.Mobile_Number = model.MobileNumber;
                    entity.Sex_Id = model.Sex.Id;
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
