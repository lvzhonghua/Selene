using Selene.BaseControl.PropertyExtend;
using Selene.BaseControl.PropertyExtend.Metadata;
using Selene.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.UIUtils
{
    public class LineageGridConfig : PropertyGridBase<Lineage>
    {
        public override void InitConfig()
        {
            this.Property(m => m.WorldNumberComments)
                .HasAttribute(new DisplayNameAttribute("世系说明"))
                .HasAttribute(new CategoryAttribute("世系信息"))
                .HasAttribute(new DescriptionAttribute("世系说明信息"));

            this.Property(m => m.AncestorWroldNumberName)
                .HasAttribute(new DisplayNameAttribute("始祖世系名称"))
                .HasAttribute(new CategoryAttribute("世系信息"))
                .HasAttribute(new DescriptionAttribute("始祖世系的名称相关信息"));

            this.Property(m => m.EdgeTitle)
                .HasAttribute(new DisplayNameAttribute("页边标题"))
                .HasAttribute(new CategoryAttribute("世系信息"))
                .HasAttribute(new DescriptionAttribute("页边标题信息"));

            this.Property(m => m.TopTitle)
                .HasAttribute(new DisplayNameAttribute("顶栏标题"))
                .HasAttribute(new CategoryAttribute("世系信息"))
                .HasAttribute(new DescriptionAttribute("顶栏标题信息"));

            this.Property(m => m.WorldNumberPrefix)
                .HasAttribute(new DisplayNameAttribute("世数前缀"))
                .HasAttribute(new CategoryAttribute("世系信息"))
                .HasAttribute(new DescriptionAttribute("世数前缀"));

            this.Property(m => m.WorldNumberSuffix)
                .HasAttribute(new DisplayNameAttribute("世数后缀"))
                .HasAttribute(new CategoryAttribute("世系信息"))
                .HasAttribute(new DescriptionAttribute("世数后缀"));
        }
    }
}