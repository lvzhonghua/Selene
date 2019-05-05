using Selene.BaseControl.PropertyExtend.Metadata;
using Selene.Logical.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Selene.BaseControl.PropertyExtend
{
    public abstract class PropertyGridBase<TModel> : ModelMetadataAttributeConfiguration<TModel> where TModel : class
    {
        protected TModel currentModel;

        public abstract void InitConfig();

        public PropertyManageCls GetPropertyGrid(TModel model)
        {
            this.currentModel = model;
            InitConfig();

            PropertyManageCls pmc = new PropertyManageCls();
            pmc.OldObject = model;

            var keys = this.Properties.Keys;
            var properties = model.GetType().GetProperties();
            List<Property> plist = new List<Property>();
            int index = 0;

            foreach (var key in keys)
            {
                var propertyMetadata = this.Properties[key];

                var defaultValueAttr = propertyMetadata.GetAttribute<DefaultValueAttribute>();
                object defaultValue = null;
                if (defaultValueAttr != null)
                {
                    defaultValue = defaultValueAttr.Value;
                }

                PropertyInfo pi = properties.Where(p => p.Name.Equals(key)).First();
                object value = pi.GetValue(model);
                if (pi.PropertyType == typeof(Color))
                {
                    if (defaultValue == null)
                    {
                        defaultValue = Color.White;
                    }
                    value = value == null ? defaultValue : value;
                }
                else
                {
                    if (defaultValue == null)
                    {
                        defaultValue = "";
                    }
                    value = value == null ? defaultValue : value.ToString();
                }

                Property pp = new Property(key, value);

                var displayNameAttr = propertyMetadata.GetAttribute<DisplayNameAttribute>();
                if (displayNameAttr != null)
                {
                    pp.DisplayName = displayNameAttr.DisplayName;
                }

                var categoryAttr = propertyMetadata.GetAttribute<CategoryAttribute>();
                if (categoryAttr != null)
                {
                    pp.Category = categoryAttr.Category;
                }

                var descriptionAttr = propertyMetadata.GetAttribute<DescriptionAttribute>();
                if (descriptionAttr != null)
                {
                    pp.Description = descriptionAttr.Description;
                }

                var browsableAttr = propertyMetadata.GetAttribute<BrowsableAttribute>();
                if (browsableAttr != null)
                {
                    pp.IsBrowsable = browsableAttr.Browsable;
                }

                var readOnlyAttr = propertyMetadata.GetAttribute<ReadOnlyAttribute>();
                if (readOnlyAttr != null)
                {
                    pp.ReadOnly = readOnlyAttr.IsReadOnly;
                }

                var typeConverterAttr = propertyMetadata.GetAttribute<TypeConverterAttribute>();
                if (typeConverterAttr != null)
                {
                    pp.Converter = Activator.CreateInstance(Type.GetType(typeConverterAttr.ConverterTypeName)) as TypeConverter;
                }

                var editorAttr = propertyMetadata.GetAttribute<EditorAttribute>();
                if (editorAttr != null)
                {
                    pp.Editor = Activator.CreateInstance(Type.GetType(editorAttr.EditorTypeName));
                }

                pp.Order = index;
                plist.Add(pp);

                index++;
            }
            pmc.AddRange(plist.OrderBy(m => m.Order).ToList());

            return pmc;
        }
    }
}
