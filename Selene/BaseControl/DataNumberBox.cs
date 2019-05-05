using Selene.BaseControl.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.BaseControl
{
    public class DataNumberBox : TextBox, IDataControl
    {
        private string columnName;

        private string modelName;

        [Category("Custom Property")]
        [Description("对应实体中的Property")]
        public string PropertyName
        {
            get
            {
                return columnName;
            }
            set
            {
                this.columnName = value;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            char kc = e.KeyChar;
            if ((kc < 48 || kc > 57) && kc != 8)
                e.Handled = true;
        }

        [Category("Custom Property")]
        [Description("对应要取的实体的名称")]
        public string ModelName
        {
            get
            {
                return this.modelName;
            }
            set
            {
                this.modelName = value;
            }
        }
    }
}
