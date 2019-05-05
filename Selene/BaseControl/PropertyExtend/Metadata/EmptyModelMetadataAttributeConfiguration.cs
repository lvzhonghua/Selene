using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selene.BaseControl.PropertyExtend.Metadata
{
    internal class EmptyModelMetadataAttributeConfiguration : IModelMetadataAttribute
    {
        internal Attribute[] EmptyAttribute = new Attribute[0];
        internal static EmptyModelMetadataAttributeConfiguration Current { get; private set; }


        static EmptyModelMetadataAttributeConfiguration()
        {
            Current = new EmptyModelMetadataAttributeConfiguration();
        }

        IEnumerable<Attribute> IModelMetadataAttribute.GetMetadataAttributes()
        {
            return EmptyAttribute;
        }

        IEnumerable<Attribute> IModelMetadataAttribute.GetMetadataAttributes(string propertyName)
        {
            return EmptyAttribute;
        }
    }
}
