using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Test
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void menuFile_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (MessageBox.Show("确定要退出程序吗？",
                                                         "确认",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question)
                              == DialogResult.No);
        }

        private void menuTechTest_Lineage_Click(object sender, EventArgs e)
        {
            FormLineage frmLineage = FormLineage.Instance;
            frmLineage.MdiParent = this;
            frmLineage.Show();
            frmLineage.Activate();
        }

        private void menuTechTest_Paging_Click(object sender, EventArgs e)
        {
            FormPaging frmPaging = FormPaging.Instance;
            frmPaging.MdiParent = this;
            frmPaging.Show();
            frmPaging.Activate();
        }

        private void menuTechTest_PageStyle_Click(object sender, EventArgs e)
        {
            FormPageStyleDesginer frmPageStyle = FormPageStyleDesginer.Instance;
            frmPageStyle.MdiParent = this;
            frmPageStyle.Show();
            frmPageStyle.Activate();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormTestDrawPanel frmTestDrawPanel = new FormTestDrawPanel();
            frmTestDrawPanel.MdiParent = this;
            frmTestDrawPanel.Show();

            FormPrintTest frmPrintTest = new FormPrintTest();
            frmPrintTest.MdiParent = this;
            frmPrintTest.Show();
        }
    }
}
