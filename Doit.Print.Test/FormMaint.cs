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
            this.ShowForm(typeof(FormCellStyleDesigner));
        }

        private void menuTest_GDI_Click(object sender, EventArgs e)
        {
            this.ShowForm(typeof(FormGDI));
        }

        private void ShowForm(Type formType)
        {
            Form form = Doit.UI.FormHelper.FindForm(formType.FullName, formType);
            form.MdiParent = this;
            form.Show();
            form.Activate();
        }

        private void menuTest_GEO_Click(object sender, EventArgs e)
        {
            this.ShowForm(typeof(FormGEO));
        }
    }
}
