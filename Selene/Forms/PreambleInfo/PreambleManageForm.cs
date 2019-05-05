using Selene.BaseControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Forms.PreambleInfo
{
    public partial class PreambleManageForm : FormBase
    {
        public PreambleManageForm()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            PreambleCategoryManageForm preambleCategoryManageForm = new PreambleCategoryManageForm();
            preambleCategoryManageForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
