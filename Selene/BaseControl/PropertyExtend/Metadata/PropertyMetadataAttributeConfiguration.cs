using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selene.BaseControl.PropertyExtend.Metadata
{
    public class PropertyMetadataAttributeConfiguration<TProperty> : MetadataAttributeConfiguration, IPropertyMetadataAttribute
    {
        public PropertyMetadataAttributeConfiguration<TProperty> HasAttribute<TAttribute>(TAttribute attribute) where TAttribute : Attribute
        {
            this.AddAttribute(attribute);
            return this;
        }

        IEnumerable<Attribute> IPropertyMetadataAttribute.GetAttributes()
        {
            return this.GetAttributes();
        }



        public TAttribute GetAttribute<TAttribute>() where TAttribute : class
        {
            Attribute att = this.GetAttributes().Where(a => a.GetType() == typeof(TAttribute)).FirstOrDefault();
            if (att == null)
            {
                return null;
            }
            return att as TAttribute;
        }
    }
}
