using Selene.BaseControl;
using Selene.Forms.PartVolume.PartVolumeManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Forms.PartVolume
{
    public partial class PartVolumeSettingForm : FormBase
    {
        public PartVolumeSettingForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPartVolumeManage_Click(object sender, EventArgs e)
        {
            PartVolumeManageForm partVolumeManageForm = new PartVolumeManageForm();
            partVolumeManageForm.ShowDialog();
        }
    }
}
