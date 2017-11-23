using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using SchoolMall.Model.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Business
{
    public class RoleLogic : BusinessBaseLogic<Role, ROLE>
    {
        public RoleLogic()
        {
            translator = new RoleTranslator();
        }
    }
}
