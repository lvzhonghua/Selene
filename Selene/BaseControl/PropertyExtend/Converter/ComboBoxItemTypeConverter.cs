using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.BaseControl.PropertyExtend.Converter
{
    public abstract class ComboBoxItemTypeConverter : TypeConverter
    {

        protected Dictionary<object, object> dataDict = null;


        public ComboBoxItemTypeConverter()
        {

            dataDict = new Dictionary<object, object>();

            GetConvertHash();

        }

        public abstract void GetConvertHash();

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] ids = new string[dataDict.Values.Count];
            int i = 0;
            foreach (var myDE in dataDict)
            {
                ids[i++] = myDE.Key.ToString();
            }
            return new StandardValuesCollection(ids);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object v)
        {

            if (v is string)
            {
                foreach (var myDE in dataDict)
                {
                    if (myDE.Value.Equals((v.ToString())))
                        return myDE.Key;
                }
            }
            return base.ConvertFrom(context, culture, v);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object v, Type destinationType)
        {

            if (destinationType == typeof(string))
            {
                foreach (var myDE in dataDict)
                {
                    if (myDE.Key.Equals(v))
                        return myDE.Value.ToString();

                }
                return "";
            }

            return base.ConvertTo(context, culture, v, destinationType);
        }


        //true enable,false disable
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        //true: disable text editting.    false: enable text editting;
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }

}
