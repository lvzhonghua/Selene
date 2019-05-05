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
    public class DataListBox : ListBox, IDataControl
    {

        public DataListBox()
        {
            this.DisplayMember = "Text";
            this.ValueMember = "Value";
        }

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
