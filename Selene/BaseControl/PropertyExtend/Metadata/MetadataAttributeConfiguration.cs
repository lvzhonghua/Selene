using Selene.Logical.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Selene.BaseControl.PropertyExtend.Metadata
{
    public class MetadataAttributeConfiguration
    {
        private List<Attribute> Attributes { get; set; }


        public MetadataAttributeConfiguration()
        {
            this.Attributes = new List<Attribute>();
        }

        internal void AddAttribute<TAttribute>(TAttribute attribute) where TAttribute : Attribute
        {
#if DEBUG
            if (attribute == null)
            {
                throw new ArgumentNullException("attribute");
            }
            else if (attribute is ObsoleteAttribute)
            {
                throw new NotSupportedException(string.Format("{0} is not supported", attribute.GetType().FullName));
            }

            var attributeUsage = typeof(TAttribute)
                                 .GetCustomAttributes(true)
                                 .OfType<AttributeUsageAttribute>()
                                 .FirstOrDefault();

            if ((attributeUsage != null) &&
                (attributeUsage.AllowMultiple == false))
            {
                if (this.Attributes.Where(a => a.GetType() == attribute.GetType()).Count() > 0)
                {
                    throw new TargetParameterCountException(string.Format("{0} should not have multiple same type attribute", attribute.TypeId));
                }
            }
#endif

            this.Attributes.Add(attribute);
        }

        public static string GetPropertyName<TModel, TProperty>(Expression<Func<TModel, TProperty>> propertyExpression)
        {
            return PropertyExpression.GetPropertyName(propertyExpression);
        }

        internal virtual IEnumerable<Attribute> GetAttributes()
        {
            return this.Attributes;
        }
    }
}
