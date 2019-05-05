using Selene.BaseControl.PropertyExtend.Converter;
using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.SettingModel.CommonConvert
{
    public class YesNOConverter : ComboBoxItemTypeConverter
    {
        public override void GetConvertHash()
        {
            dataDict.Add("True", "是");
            dataDict.Add("False", "否");
        }
    }
}
