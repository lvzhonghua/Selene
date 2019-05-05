using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.BaseControl.PropertyExtend
{
    public class Property
    {

        public Property(string sName, object sValue)
        {
            this.Name = sName;
            this.Value = sValue;
        }
        public Property(string sName, object sValue, bool sReadonly, bool sVisible)
        {
            this.Name = sName;
            this.Value = sValue;
            this.ReadOnly = sReadonly;
            this.Visible = sVisible;
        }
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public TypeConverter Converter { get; set; }

        public string Category { get; set; }

        public object Value { get; set; }

        public bool ReadOnly { get; set; }

        public bool Visible { get; set; }

        public bool IsBrowsable { get; set; }

        public virtual object Editor { get; set; }

        public int Order { get; set; }
    }
}
