using Selene.BaseControl.PropertyExtend.Converter;
using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.SettingModel.Book.HTStyle.Convert
{
    public class HFStyleConverter : ComboBoxItemTypeConverter
    {
        public override void GetConvertHash()
        {
            dataDict.Add(HeaderFooterStyle.Tradition.ToString(), "传统式");
            dataDict.Add(HeaderFooterStyle.Modern.ToString(), "现代式");
        }
    }
}
