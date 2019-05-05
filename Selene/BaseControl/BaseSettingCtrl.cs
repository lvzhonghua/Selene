using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.BaseControl
{
    public partial class BaseSettingCtrl : DataCtrlBase
    {
        public BaseSettingCtrl()
        {
            InitializeComponent();
        }

        public virtual bool SaveEvent()
        {
            return true;
        }

        public virtual bool CloseEvent()
        {
            return true;
        }

        public virtual void CtrlLoad()
        {

        }

        private void BaseSettingCtrl_Load(object sender, EventArgs e)
        {
            CtrlLoad();

            this.Dock = DockStyle.Fill;
            this.Location = new Point(0, 0);
        }
    }
}
