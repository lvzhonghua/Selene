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
    public partial class BasePropertyGridSettingCtrl : BaseSettingCtrl
    {
        public BasePropertyGridSettingCtrl()
        {
            InitializeComponent();
        }

        

        private void IBaseSettingCtrl_Load(object sender, EventArgs e)
        {
            

            CtrlLoad();
        }

    }
}
