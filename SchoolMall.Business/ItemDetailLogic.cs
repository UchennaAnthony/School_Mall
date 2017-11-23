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
    public class ItemDetailLogic: BusinessBaseLogic<ItemDetail, ITEM_DETAIL>
    {
        public ItemDetailLogic()
        {
            translator = new ItemDetailTranslator();
        }
    }
}
