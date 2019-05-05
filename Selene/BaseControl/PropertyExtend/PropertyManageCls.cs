using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.BaseControl.PropertyExtend
{
    public class PropertyManageCls : List<Property>, ICustomTypeDescriptor
    {
        public Object OldObject { get; set; }

        public new void Add(Property value)
        {
            int flag = -1;
            if (value != null)
            {
                if (base.Count > 0)
                {
                    IList<Property> mList = new List<Property>();
                    for (int i = 0; i < base.Count; i++)
                    {
                        Property p = base[i] as Property;
                        if (value.Name == p.Name)
                        {
                            flag = i;
                        }
                        mList.Add(p);
                    }
                    if (flag == -1)
                    {
                        mList.Add(value);
                    }
                    base.Clear();
                    foreach (Property p in mList)
                    {
                        base.Add(p);
                    }
                }
                else
                {
                    base.Add(value);
                }
            }
        }
        public new void Remove(Property value)
        {
            if (value != null && base.Count > 0)
                base.Remove(value);
        }
        public new Property this[int index]
        {
            get
            {
                return (Property)base[index];
            }
            set
            {
                base[index] = (Property)value;
            }
        }
        #region ICustomTypeDescriptor 成员
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptor[] newProps = new PropertyDescriptor[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                Property prop = (Property)this[i];
                newProps[i] = new CustomPropertyDescriptor(ref prop, attributes);
            }
            return new PropertyDescriptorCollection(newProps);
        }
        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(this, true);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        #endregion
    }
}
