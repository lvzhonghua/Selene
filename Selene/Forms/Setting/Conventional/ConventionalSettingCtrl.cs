using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Selene.BaseControl;
using Selene.UIUtils;
using Selene.Model.SettingModel.Book;

namespace Selene.Forms.Setting.Conventional
{
    public partial class ConventionalSettingCtrl : BasePropertyGridSettingCtrl
    {
        public ConventionalSettingCtrl()
        {
            InitializeComponent();
        }

        public override void CtrlLoad()
        {
            base.CtrlLoad();

            SetConventionalSetting();

        }

        private void SetConventionalSetting()
        {
            this.pgMain.SelectedObject = PropertyGridUtil.GetObject<ConventionalSetting>();
        }
    }
}
