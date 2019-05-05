using Selene.BaseControl;
using Selene.BaseControl.Enums;
using Selene.DB.Enums;
using Selene.Logical;
using Selene.Model;
using Selene.Providers.Base;
using Selene.UIUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Forms.PartVolume.PartVolumeManage
{
    public partial class PartVolumeDetailedForm : FormBase
    {
        public PartVolumeDetailedForm()
        {
            InitializeComponent();
            volumeBLL = new VolumeBLL();
        }
        private VolumeBLL volumeBLL;
        private PartVolumeManageForm volumeManageForm;
        private Volume currentVolume;

        public void SetVolume(Volume volume)
        {
            this.currentVolume = volume;
        }

        public void SetVolumeManageForm(PartVolumeManageForm volumeManageForm)
        {
            this.volumeManageForm = volumeManageForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text;

            if (string.IsNullOrEmpty(name))
            {
                UICommonUtil.MessageBoxShow("卷名不能为空");
                return;
            }
            int volumeId = 0;
            if (currentVolume != null)
            {
                volumeId = currentVolume.Id;
            }
            if (volumeBLL.ExistVolume(name, volumeId))
            {
                UICommonUtil.MessageBoxShow("已经存在对应的卷名");
                return;
            }

            if (currentVolume!=null)
            {
                currentVolume.ModelStatus = ModelStatus.Update;
            }
            else
            {
                currentVolume = new Volume();
                currentVolume.ModelStatus = ModelStatus.Add;
                currentVolume.Sort = volumeManageForm.GetVolumeSumCount() ;
            }
            currentVolume.Name = name;
            currentVolume.StartIndex = int.Parse(this.numStartIndex.Text);
            currentVolume.NeedCatalogue = this.cboNeedCatalogue.Checked;
            currentVolume.NeedCheatSheets = this.cboNeedCheatSheets.Checked;

            if (volumeBLL.ApplyChange(currentVolume))
            {
                volumeManageForm.ReloadDataSource();
                this.Close();
            }
            else
            {
                UICommonUtil.MessageBoxShow("保存分卷出错");
            }
        }

        private void PartVolumeDetailedForm_Load(object sender, EventArgs e)
        {
            this.numStartIndex.Text = "1";
            if (this.currentVolume!=null)
            {
                this.txtName.Text = currentVolume.Name;
                this.numStartIndex.Text = currentVolume.StartIndex.ToString();
                this.cboNeedCatalogue.Checked = currentVolume.NeedCatalogue;
                this.cboNeedCheatSheets.Checked = currentVolume.NeedCheatSheets;
            }
        }
    }
}
