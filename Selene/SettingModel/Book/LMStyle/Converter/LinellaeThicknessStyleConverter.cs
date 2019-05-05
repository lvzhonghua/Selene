using Selene.BaseControl.PropertyExtend.Converter;
using Selene.Model.Enums;
using Selene.Model.Enums.Lineage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.SettingModel.Book.HTStyle.Convert
{
    public class LinellaeThicknessStyleConverter : ComboBoxItemTypeConverter
    {
        public override void GetConvertHash()
        {
            dataDict.Add(LinellaeThicknessStyle.ThanThick.ToString(), "较粗");
            dataDict.Add(LinellaeThicknessStyle.Thick.ToString(), "粗线");
            dataDict.Add(LinellaeThicknessStyle.General.ToString(), "一般");
            dataDict.Add(LinellaeThicknessStyle.Thin.ToString(), "细线");
            dataDict.Add(LinellaeThicknessStyle.ThanThin.ToString(), "较细");
        }
    }
}
