using Selene.BaseControl.PropertyExtend.Converter;
using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.SettingModel.Book.HTStyle.Convert
{
    public class LineStyleConverter : ComboBoxItemTypeConverter
    {
        public override void GetConvertHash()
        {
            dataDict.Add(LineStyle.Thick.ToString(), "粗线");
            dataDict.Add(LineStyle.Thin.ToString(), "细线");
        }
    }
}
