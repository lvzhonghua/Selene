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
    public class LineageMapStyleConverter : ComboBoxItemTypeConverter
    {
        public override void GetConvertHash()
        {
            dataDict.Add(LineageMapStyle.MessengerWire.ToString(), "吊线式世系图");
            dataDict.Add(LineageMapStyle.Box.ToString(), "方框式世系图");
        }
    }
}
