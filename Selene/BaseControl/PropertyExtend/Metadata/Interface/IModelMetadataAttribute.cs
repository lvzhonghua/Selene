using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selene.BaseControl.PropertyExtend.Metadata
{
    internal interface IModelMetadataAttribute
    {
        IEnumerable<Attribute> GetMetadataAttributes();
        IEnumerable<Attribute> GetMetadataAttributes(string propertyName);
    }
}
