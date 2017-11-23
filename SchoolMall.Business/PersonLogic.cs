using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using SchoolMall.Model.Translator;


namespace SchoolMall.Business
{
    public class PersonLogic : BusinessBaseLogic<Person, PERSON>
    {
        public PersonLogic()
        {
            translator = new PersonTranslator();
        }
        public bool Modify(Person person)
        {
            try
            {
                PERSON entity = GetEntityBy(s => s.Person_Id == person.Id);

                if (entity != null)
                {

                    entity.Person_Id = person.Id;
                    if (person.ContactAddress != null)
                    {
                        entity.Contact_Address = person.ContactAddress;  
                    }
                    if (person.FirstName != null)
                    {
                        entity.First_Name = person.FirstName;
                    }
                    if (person.LastName != null)
                    {
                        entity.Last_Name = person.LastName;
                    }
                    if (person.MobileNumber != null)
                    {
                        entity.Mobile_Number = person.MobileNumber;
                    }
                    if (person.OtherName != null)
                    {
                        entity.Other_Name = person.OtherName;
                    }
                    if (person.Sex != null)
                    {
                        entity.Sex_Id = person.Sex.Id;
                    }
                    int modifiedRecordCount = Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
