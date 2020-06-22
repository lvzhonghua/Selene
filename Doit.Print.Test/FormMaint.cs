using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doit.Print.Test
{
    public partial class FormMaint : Form
    {
        public FormMaint()
        {
            InitializeComponent();
        }

        private void menuFile_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMaint_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (MessageBox.Show("确定退出程序吗？","确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No);
        }

        private void menuTest_CellStyleDesginer_Click(object sender, EventArgs e)
        {
            Form frmCellStyleDesigner = Doit.UI.FormHelper.FindForm("CellStyleDesigner", typeof(FormCellStyleDesigner));
            frmCellStyleDesigner.MdiParent = this;
            frmCellStyleDesigner.Show();
            frmCellStyleDesigner.Activate();
        }
    }
}
