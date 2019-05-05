using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selene.BaseControl.PropertyExtend.Metadata
{
    public interface IPropertyMetadataAttribute
    {
        IEnumerable<Attribute> GetAttributes();

        TAttribute GetAttribute<TAttribute>() where TAttribute : class;
    }
}
