using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Selene.SettingModel.CommonConvert
{
    public class MyFontEditor : FontEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (edSvc != null)
            {
                FontDialog fd = new FontDialog();
                fd.ShowEffects = false;
                fd.AllowSimulations = false;
                fd.AllowVectorFonts = false;
                fd.AllowScriptChange = false;

                string valueStr = value == null ? "" : value.ToString();

                if (!string.IsNullOrEmpty(valueStr))
                {
                    string[] fonts = valueStr.Split(',');
                    fd.Font = new Font(fonts[0], float.Parse(fonts[1]));
                }


                if (DialogResult.OK == fd.ShowDialog())
                {
                    return fd.Font.Name + "," + fd.Font.Size;
                }
            }
            return value;
        }
    }
}
