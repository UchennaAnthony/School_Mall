using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class RoleTranslator : TranslatorBase<Role, ROLE>
    {
        public override Role TranslateToModel(ROLE entity)
        {
            try
            {
                Role model = null;
                if (entity != null)
                {
                    model = new Role();
                    model.Id = entity.Role_Id;
                    model.Activated = entity.Activated;
                    model.RoleName = entity.Role_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override ROLE TranslateToEntity(Role model)
        {
            try
            {
                ROLE entity = null;
                if (model != null)
                {
                    entity = new ROLE();
                    entity.Role_Id = model.Id;
                    entity.Activated = model.Activated;
                    entity.Role_Name = model.RoleName;
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
