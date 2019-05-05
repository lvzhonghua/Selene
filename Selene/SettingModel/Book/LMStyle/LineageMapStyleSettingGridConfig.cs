using Selene.BaseControl.PropertyExtend;
using Selene.Model.Enums;
using Selene.Model.SettingModel.Book;
using Selene.SettingModel.Book.HTStyle.Convert;
using Selene.SettingModel.CommonConvert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.SettingModel.Book.LMStyle
{
    public class LineageMapStyleSettingGridConfig<TModel> : PropertyGridBase<TModel> where TModel : LineageMapStyleSetting
    {
        public override void InitConfig()
        {
            CategoryAttribute categoryAttr = new CategoryAttribute("世系图设置");

            this.Property(m => m.LMStyle)
                .HasAttribute(new DisplayNameAttribute("世系图类型"))
                .HasAttribute(categoryAttr)
                .HasAttribute(new TypeConverterAttribute(typeof(LineageMapStyleConverter)));

            this.Property(m => m.LinellaeThickness)
                .HasAttribute(new DisplayNameAttribute("线条粗细"))
                .HasAttribute(categoryAttr)
                .HasAttribute(new TypeConverterAttribute(typeof(LinellaeThicknessStyleConverter)));

            this.Property(m => m.LinellaeColor)
                .HasAttribute(new DisplayNameAttribute("线条颜色"))
                .HasAttribute(new EditorAttribute(typeof(ColorEditor), typeof(UITypeEditor)))
                .HasAttribute(new TypeConverterAttribute(typeof(ColorConverter)))
                .HasAttribute(categoryAttr);

            this.Property(m => m.LiftAtPageNumber)
                .HasAttribute(new DisplayNameAttribute("世表所在页码"))
                .HasAttribute(categoryAttr);

            this.Property(m => m.LineageMapNote)
                .HasAttribute(new DisplayNameAttribute("世系图说明"))
                .HasAttribute(categoryAttr);



            CategoryAttribute categoryAttrFont = new CategoryAttribute("字体设置");
            if (currentModel.LMStyle == LineageMapStyle.MessengerWire)
            {
                categoryAttrFont = new CategoryAttribute("字体、行距、字距设置");
            }

            this.Property(m => m.TitleFont)
                .HasAttribute(new DisplayNameAttribute("标题字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.LineageNoteFont)
                .HasAttribute(new DisplayNameAttribute("世系说明字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.WorldNumberFont)
                .HasAttribute(new DisplayNameAttribute("世数字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.ClansmanName)
                .HasAttribute(new DisplayNameAttribute("谱名字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.AnnotationFont)
                .HasAttribute(new DisplayNameAttribute("标注字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));
        }
    }
}
