using Selene.Model.SettingModel.Book;
using Selene.SettingModel.CommonConvert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.SettingModel.Book.LMStyle
{
    public class BoxLineageMapStyleSettingGridConfig : LineageMapStyleSettingGridConfig<BoxLineageMapStyleSetting>
    {
        public override void InitConfig()
        {
            base.InitConfig();


            CategoryAttribute categoryAttr = new CategoryAttribute("世系图设置");

            this.Property(m => m.HeirTag)
                .HasAttribute(new DisplayNameAttribute("嗣子标识"))
                .HasAttribute(categoryAttr);

            this.Property(m => m.TiaoSonTag)
                .HasAttribute(new DisplayNameAttribute("祧子标识"))
                .HasAttribute(categoryAttr);

            this.Property(m => m.GirlTag)
                .HasAttribute(new DisplayNameAttribute("女孩标识"))
                .HasAttribute(categoryAttr);


            CategoryAttribute categoryAttrFont = new CategoryAttribute("字体设置");

            this.Property(m => m.LineageMapPrintPlace)
                .HasAttribute(new DisplayNameAttribute("世系图打印位置"))
                .HasAttribute(categoryAttrFont);

            this.Property(m => m.PageFont)
                .HasAttribute(new DisplayNameAttribute("页码字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));
        }
    }
}
