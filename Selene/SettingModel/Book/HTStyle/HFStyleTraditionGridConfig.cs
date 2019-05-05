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
    public class HFStyleTraditionGridConfig : PropertyGridBase<HFStyleTradition>
    {
        public override void InitConfig()
        {
            #region 横板页眉页脚设置

            CategoryAttribute categoryAttr = new CategoryAttribute("横板页眉页脚设置");

            this.Property(m => m.HFStyle)
                .HasAttribute(new DisplayNameAttribute("页眉页脚样式"))
                .HasAttribute(categoryAttr)
                .HasAttribute(new TypeConverterAttribute(typeof(HFStyleConverter)))
                .HasAttribute(new DefaultValueAttribute(HeaderFooterStyle.Tradition));

            this.Property(m => m.HeaderCenterFont)
                .HasAttribute(new DisplayNameAttribute("页眉中部字体"))
                .HasAttribute(categoryAttr)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.OtherFont)
                .HasAttribute(new DisplayNameAttribute("其它部分字体"))
                .HasAttribute(categoryAttr)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.EvenPageTitle)
                .HasAttribute(new DisplayNameAttribute("偶数页标题"))
                .HasAttribute(categoryAttr);

            this.Property(m => m.PageNumberFont)
                .HasAttribute(new DisplayNameAttribute("页码字体"))
                .HasAttribute(categoryAttr)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.ForceSeqLineageHF)
                .HasAttribute(new DisplayNameAttribute("强制谱序和世系图中打印页眉页脚"))
                .HasAttribute(new TypeConverterAttribute(typeof(YesNOConverter)))
                .HasAttribute(categoryAttr);

            #endregion

            #region 线条样式
            this.Property(m => m.HeaderLineStyle)
                .HasAttribute(new DisplayNameAttribute("页眉式样"))
                .HasAttribute(new TypeConverterAttribute(typeof(LineStyleConverter)))
                .HasAttribute(new CategoryAttribute("线条样式"));

            this.Property(m => m.FooterLineStyle)
                .HasAttribute(new DisplayNameAttribute("页脚式样"))
                .HasAttribute(new TypeConverterAttribute(typeof(LineStyleConverter)))
                .HasAttribute(new CategoryAttribute("线条样式"));

            this.Property(m => m.ThickWidth)
                .HasAttribute(new DisplayNameAttribute("粗线宽度"))
                .HasAttribute(new CategoryAttribute("线条样式"));

            this.Property(m => m.ThinWidth)
                .HasAttribute(new DisplayNameAttribute("细线宽度"))
                .HasAttribute(new CategoryAttribute("线条样式"));

            this.Property(m => m.LineSpace)
                .HasAttribute(new DisplayNameAttribute("线条间距"))
                .HasAttribute(new CategoryAttribute("线条样式"));

            #endregion

            #region 页眉

            this.Property(m => m.HeaderLeft)
                .HasAttribute(new DisplayNameAttribute("左"))
                .HasAttribute(new CategoryAttribute("页眉"));

            this.Property(m => m.HeaderCenter)
                .HasAttribute(new DisplayNameAttribute("中"))
                .HasAttribute(new CategoryAttribute("页眉"));

            this.Property(m => m.HeaderRight)
                .HasAttribute(new DisplayNameAttribute("右"))
                .HasAttribute(new CategoryAttribute("页眉"));

            #endregion

            #region 页脚

            this.Property(m => m.FooterLeft)
                .HasAttribute(new DisplayNameAttribute("左"))
                .HasAttribute(new CategoryAttribute("页脚"));

            this.Property(m => m.FooterCenter)
                .HasAttribute(new DisplayNameAttribute("中"))
                .HasAttribute(new CategoryAttribute("页脚"));

            this.Property(m => m.FooterRight)
                .HasAttribute(new DisplayNameAttribute("右"))
                .HasAttribute(new CategoryAttribute("页脚"));

            #endregion
        }
    }
}
