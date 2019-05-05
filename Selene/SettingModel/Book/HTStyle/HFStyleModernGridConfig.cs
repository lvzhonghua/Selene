using Selene.BaseControl.PropertyExtend;
using Selene.Model.Enums;
using Selene.Model.SettingModel.Book.HFStyle;
using Selene.SettingModel.Book.HTStyle.Convert;
using Selene.SettingModel.CommonConvert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.SettingModel.Book.HTStyle
{
    public class HFStyleModernGridConfig : PropertyGridBase<HFStyleModern>
    {
        public override void InitConfig()
        {
            #region 横板页眉页脚设置
            this.Property(m => m.HFStyle)
                .HasAttribute(new DisplayNameAttribute("页眉页脚样式"))
                .HasAttribute(new CategoryAttribute("横板页眉页脚设置"))
                .HasAttribute(new TypeConverterAttribute(typeof(HFStyleConverter)))
                .HasAttribute(new DefaultValueAttribute(HeaderFooterStyle.Modern));

            this.Property(m => m.TopBottomTitleFont)
                .HasAttribute(new DisplayNameAttribute("上下标题字体"))
                .HasAttribute(new CategoryAttribute("横板页眉页脚设置"))
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.EdgeTitleFont)
                .HasAttribute(new DisplayNameAttribute("页边标题字体"))
                .HasAttribute(new CategoryAttribute("横板页眉页脚设置"))
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.EvenPageTitle)
                .HasAttribute(new DisplayNameAttribute("偶数页标题"))
                .HasAttribute(new CategoryAttribute("横板页眉页脚设置"));

            this.Property(m => m.PageNumberFont)
                .HasAttribute(new DisplayNameAttribute("页码字体"))
                .HasAttribute(new CategoryAttribute("横板页眉页脚设置"))
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            #endregion

            #region 页边
            this.Property(m => m.EdgeTop)
                .HasAttribute(new DisplayNameAttribute("上"))
                .HasAttribute(new CategoryAttribute("页边"));

            this.Property(m => m.EdgeCenter)
                .HasAttribute(new DisplayNameAttribute("中"))
                .HasAttribute(new CategoryAttribute("页边"));

            this.Property(m => m.EdgeBottom)
                .HasAttribute(new DisplayNameAttribute("下"))
                .HasAttribute(new CategoryAttribute("页边"));

            #endregion
        }
    }
}
