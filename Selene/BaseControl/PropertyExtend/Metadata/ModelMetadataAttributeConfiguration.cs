
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Selene.BaseControl.PropertyExtend.Metadata
{
    public class ModelMetadataAttributeConfiguration<TModel> : MetadataAttributeConfiguration, IModelMetadataAttribute where TModel : class
    {
        protected Dictionary<string, IPropertyMetadataAttribute> Properties { get; set; }


        public ModelMetadataAttributeConfiguration()
        {
            this.Properties = new Dictionary<string, IPropertyMetadataAttribute>();
        }

        protected ModelMetadataAttributeConfiguration<TModel> HasAttribute<TAttribute>(TAttribute attribute) where TAttribute : Attribute
        {
            this.AddAttribute(attribute);
            return this;
        }

        protected PropertyMetadataAttributeConfiguration<TProperty> Property<TProperty>(Expression<Func<TModel, TProperty>> propertyExpression)
        {
            var propertyName = GetPropertyName(propertyExpression);
            if (!this.Properties.ContainsKey(propertyName))
            {
                this.Properties.Add(propertyName, new PropertyMetadataAttributeConfiguration<TProperty>());
            }

            return this.Properties[propertyName] as PropertyMetadataAttributeConfiguration<TProperty>;
        }

        IEnumerable<Attribute> IModelMetadataAttribute.GetMetadataAttributes()
        {
            return this.GetAttributes();
        }

        IEnumerable<Attribute> IModelMetadataAttribute.GetMetadataAttributes(string propertyName)
        {
            if (this.Properties.ContainsKey(propertyName))
            {
                var propertyMetadataConfig = this.Properties[propertyName];
                return propertyMetadataConfig.GetAttributes();
            }

            return EmptyModelMetadataAttributeConfiguration.Current.EmptyAttribute;
        }

        internal IEnumerable<Attribute> GetMetadataAttributes<TProperty>(Expression<Func<TModel, TProperty>> propertyExpression)
        {
            var propertyName = GetPropertyName(propertyExpression);
            return (this as IModelMetadataAttribute).GetMetadataAttributes(propertyName);
        }
    }
}
