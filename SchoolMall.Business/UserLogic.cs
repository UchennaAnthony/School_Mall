using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using SchoolMall.Model.Translator;
using System.Linq.Expressions;


namespace SchoolMall.Business
{
    public class UserLogic : BusinessBaseLogic<User, USER>
    {
        public UserLogic()
        {
            translator = new UserTranslator();
        }
        public bool ValidateUser(string Username, string Password)
        {
            try
            {
                Expression<Func<USER, bool>> selector = p => p.User_Name == Username && p.Password == Password;
                User UserDetails = GetModelBy(selector);
                if (UserDetails != null && UserDetails.Password != null)
                {
                    UpdateLastLogin(UserDetails);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateLastLogin(User user)
        {
            try
            {
                Expression<Func<USER, bool>> selector = p => p.User_Name == user.Username && p.Password == user.Password;
                USER userEntity = GetEntityBy(selector);
                if (userEntity == null || userEntity.User_Id <= 0)
                {
                    throw new Exception(NoItemFound);
                }

                userEntity.User_Name = user.Username;
                userEntity.Password = user.Password;
                userEntity.Role_Id = user.Role.Id;
                userEntity.Last_Login_Date = DateTime.Now;

                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ChangeUserPassword(User user)
        {
            try
            {
                Expression<Func<USER, bool>> selector = p => p.User_Name == user.Username;
                USER userEntity = GetEntityBy(selector);
                if (userEntity == null || userEntity.User_Id <= 0)
                {
                    throw new Exception(NoItemFound);
                }

                userEntity.User_Name = user.Username;
                userEntity.Password = user.Password;
                userEntity.Role_Id = user.Role.Id;
                userEntity.Last_Login_Date = user.LastLoginDate;

                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User Update(User model)
        {
            try
            {
                Expression<Func<USER, bool>> selector = a => a.User_Id == model.Id;
                USER entity = GetEntityBy(selector);

                entity.User_Name = model.Username;
                entity.Password = model.Password;
                entity.Role_Id = model.Role.Id;

                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Modify(User user)
        {
            try
            {
                USER entity = GetEntityBy(u => u.User_Id == user.Id);

                if (entity != null)
                {

                    entity.User_Id = user.Id;
                    if (user.Email != null)
                    {
                        entity.Email = user.Email;
                    }
                    if (user.ImageUrl != null)
                    {
                        entity.Image_Url = user.ImageUrl;
                    }
                    if (user.Password != null)
                    {
                        entity.Password = user.Password;
                    }
                    if (user.Role != null)
                    {
                        entity.Role_Id = user.Role.Id;
                    }
                    if (user.SecurityAnswer != null)
                    {
                        entity.Security_Answer = user.SecurityAnswer;
                    }
                    if (user.SecurityQuestion != null)
                    {
                        entity.Security_Question_Id = user.SecurityQuestion.Id;
                    }
                    if (user.Username != null)
                    {
                        entity.User_Name = user.Username;
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
