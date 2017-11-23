using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class UserTranslator : TranslatorBase<User, USER>
    {
        private RoleTranslator roleTranslator;
        private SecurityQuestionTranslator securityQuestionTranslator;
        private PersonTranslator personTranslator;
        public UserTranslator()
        {
            roleTranslator = new RoleTranslator();
            securityQuestionTranslator = new SecurityQuestionTranslator();
            personTranslator = new PersonTranslator();
        }
         public override User TranslateToModel(USER entity)
        {
            try
            {
                User model = null;
                if (entity != null)
                {
                    model = new User();
                    model.Id = entity.User_Id;
                    model.Email = entity.Email;
                    model.Password = entity.Password;
                    model.Role = roleTranslator.Translate(entity.ROLE);
                    model.SecurityAnswer = entity.Security_Answer;
                    model.SecurityQuestion = securityQuestionTranslator.Translate(entity.SECURITY_QUESTION);
                    model.Username = entity.User_Name;
                    model.ImageUrl = entity.Image_Url;
                    model.Person = personTranslator.Translate(entity.PERSON);
                    model.LastLoginDate = entity.Last_Login_Date;
                    }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override USER TranslateToEntity(User model)
        {
            try
            {
                USER entity = null;
                if (model != null)
                {
                    entity = new USER();
                    entity.User_Id = model.Id;
                    entity.Person_Id = model.Person.Id;
                    entity.Email = model.Email;
                    entity.Password = model.Password;
                    entity.Role_Id = model.Role.Id;
                    entity.Security_Answer = model.SecurityAnswer;
                    entity.Security_Question_Id = model.SecurityQuestion.Id;
                    entity.User_Name = model.Username;
                    entity.Image_Url = model.ImageUrl;
                    entity.Last_Login_Date = model.LastLoginDate;
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
