using Selene.BaseControl.PropertyExtend;
using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Selene.UIUtils
{
    public class PropertyGridUtil
    {
        public static PropertyManageCls GetObject<TModel>(TModel model = null) where TModel : class,new()
        {
            string name = typeof(TModel).Name;
            Type type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.FullName.Contains(string.Format("{0}GridConfig", name))).FirstOrDefault();

            if (model == null)
            {
                model = new TModel();
            }
            PropertyGridBase<TModel> pgb = Activator.CreateInstance(type) as PropertyGridBase<TModel>;

            return pgb.GetPropertyGrid(model);
        }

        public static TModel GridObject2Model<TModel>(object obj) where TModel : class,new()
        {
            if (obj == null || !(obj is PropertyManageCls))
            {
                return default(TModel);
            }

            PropertyManageCls cls = obj as PropertyManageCls;
            TModel model = null;
            if (cls.OldObject is TModel)
            {
                model = cls.OldObject as TModel;
            }
            else
            {
                model = new TModel();
            }


            var properties = model.GetType().GetProperties();
            foreach (var item in cls)
            {
                var property = properties.Where(p => item.Name.Equals(p.Name)).FirstOrDefault();
                object value = item.Value;
                if (property.PropertyType.BaseType == typeof(Enum))
                {
                    value = Enum.Parse(property.PropertyType, value.ToString());
                }
                else if (property.PropertyType == typeof(Double))
                {
                    value = Double.Parse(value.ToString());
                }
                else if (property.PropertyType == typeof(Boolean))
                {
                    value = "true".Equals(value.ToString());
                }
                if (property.PropertyType == typeof(string)&&value.GetType() == typeof(Color))
                {
                    value = ((Color)value).Name;
                }
                property.SetValue(model, value);
            }

            return model;
        }
    }
}
