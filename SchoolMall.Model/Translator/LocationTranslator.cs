using SchoolMall.Model.Entity;
using SchoolMall.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMall.Model.Translator
{
    public class LocationTranslator : TranslatorBase<Location, LOCATION>
    {
        public override Location TranslateToModel(LOCATION entity)
        {
            try
            {
                Location model = null;
                if (entity != null)
                {
                    model = new Location();
                    model.Id = entity.Location_Id;
                    model.LocationName = entity.Location_Name;
                    model.LocationDescription = entity.Location_Description;
                }
                return model;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public override LOCATION TranslateToEntity(Location model)
        {
            try
            {
                LOCATION entity = null;
                if (model != null)
                {
                    entity = new LOCATION();
                    entity.Location_Id = model.Id;
                    entity.Location_Name = model.LocationName;
                    entity.Location_Description = model.LocationDescription;
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
