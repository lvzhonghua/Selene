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
    public class MessengerWireLineageMapStyleSettingGridConfig : LineageMapStyleSettingGridConfig<MessengerWireLineageMapStyleSetting>
    {
        public override void InitConfig()
        {
            base.InitConfig();

            CategoryAttribute categoryAttr = new CategoryAttribute("世系图设置");

            this.Property(m => m.TopTitle)
                .HasAttribute(new DisplayNameAttribute("顶栏文字"))
                .HasAttribute(categoryAttr);


            var categoryAttrFont = new CategoryAttribute("字体、行距、字距设置");

            this.Property(m => m.BranchFont)
                .HasAttribute(new DisplayNameAttribute("房系字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.ContentFont)
                .HasAttribute(new DisplayNameAttribute("正文字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.UpTurnDownJoinFont)
                .HasAttribute(new DisplayNameAttribute("上转下接字体"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DisableInputTypeConvert)))
                .HasAttribute(new EditorAttribute(typeof(MyFontEditor), typeof(UITypeEditor)));

            this.Property(m => m.RowSpace)
                .HasAttribute(new DisplayNameAttribute("行间距"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DecimalConverter)));

            this.Property(m => m.CharacterSpace)
                .HasAttribute(new DisplayNameAttribute("字间距"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DecimalConverter)));

            this.Property(m => m.LineageNoteRowSpace)
                .HasAttribute(new DisplayNameAttribute("世系说明行间距"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DecimalConverter)));

            this.Property(m => m.LineageNoteCharacterSpace)
                .HasAttribute(new DisplayNameAttribute("世系说明字间距"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DecimalConverter)));

            this.Property(m => m.ClansmanNameToBorderSpace)
                .HasAttribute(new DisplayNameAttribute("谱名到边框间距"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DecimalConverter)));

            this.Property(m => m.ContentToBorderSpace)
                .HasAttribute(new DisplayNameAttribute("正文到边框间距"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DecimalConverter)));

            this.Property(m => m.ClansmanNameToPrevGenealogyNoteSpace)
                .HasAttribute(new DisplayNameAttribute("谱名到前谱文间距"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DecimalConverter)));

            this.Property(m => m.ContentToClansmanName)
                .HasAttribute(new DisplayNameAttribute("正文到谱名间距"))
                .HasAttribute(categoryAttrFont)
                .HasAttribute(new TypeConverterAttribute(typeof(DecimalConverter)));
        }
    }
}
