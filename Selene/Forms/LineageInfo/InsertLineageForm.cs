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

namespace Selene.Forms.LineageInfo
{
    public partial class InsertLineageForm : Form
    {
        public InsertLineageForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertLineageForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddPartVolume_Click(object sender, EventArgs e)
        {
            PartVolumeManageForm partVolumeManageForm = new PartVolumeManageForm();
            partVolumeManageForm.ShowDialog();
        }
    }
}
