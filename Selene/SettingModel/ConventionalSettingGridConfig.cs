using Selene.BaseControl.PropertyExtend;
using Selene.Model.SettingModel;
using Selene.Model.SettingModel.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.SettingModel
{
    public class ConventionalSettingGridConfig : PropertyGridBase<ConventionalSetting>
    {
        public override void InitConfig()
        {
            this.Property(m => m.BorderStyle)
                .HasAttribute(new DisplayNameAttribute("边框风格"))
                .HasAttribute(new CategoryAttribute("苏式体例"))
                .HasAttribute(new DescriptionAttribute("控制表格的边框风格"));

            this.Property(m => m.TableLineThickness)
                .HasAttribute(new DisplayNameAttribute("表格线粗细"))
                .HasAttribute(new CategoryAttribute("苏式体例"))
                .HasAttribute(new DescriptionAttribute("控制表格线的粗细"));
        }
    }
}
