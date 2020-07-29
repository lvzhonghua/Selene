using Doit.MindJet.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Doit.MindJet.MindTrees;

namespace Doit.MindJet.Tool
{
    public partial class FormMain : Form
    {
        private MindTree currentMindTree = null;
        private CommandStack currentCommandStack = null;
        private FormNodeList frmNodeList = null;
        private FormCommandStack frmCommandStack = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.dockPanel.Theme = new VS2015LightTheme();

            FormMindTree frmMindTree = new FormMindTree();
            frmMindTree.Activated += FrmMindTree_Activated;
            frmMindTree.Show(this.dockPanel,DockState.Document);

            FormMindFlow frmMindFlow = new FormMindFlow();
            frmMindFlow.Activated += FrmMindFlow_Activated;
            frmMindFlow.Show(this.dockPanel, DockState.Document);

            FormMindDraft frmMindDraft = new FormMindDraft();
            frmMindDraft.Show(this.dockPanel, DockState.Document);

        }

        private void FrmMindFlow_Activated(object sender, EventArgs e)
        {
        }

        private void FrmMindTree_Activated(object sender, EventArgs e)
        {
            this.currentMindTree = ((FormMindTree)sender).MindTree;
            this.currentCommandStack = ((FormMindTree)sender).CommandStack;

            if (this.frmNodeList != null && this.frmNodeList.Visible == true)
            {
                this.frmNodeList.MindTree = this.currentMindTree;
            }
            if (this.frmCommandStack != null && this.frmCommandStack.Visible == true)
            {
                this.frmCommandStack.CommandStack = this.currentCommandStack;
            }
        }

        private DockContent ShowDockContent(Type formType, DockState dockState = DockState.Document)
        {
            DockContent dockContent = Doit.UI.FormHelper.FindForm(formType.FullName, formType) as DockContent;
            if (dockContent == null) return null;

            dockContent.Show(this.dockPanel, dockState);
            dockContent.Activate();

            return dockContent;
        }

        private void btnStyleSchema_Click(object sender, EventArgs e)
        {
            this.ShowDockContent(typeof(FormStyleSchema),DockState.DockRight);
        }

        private void btnNodeList_Click(object sender, EventArgs e)
        {
            this.frmNodeList = this.ShowDockContent(typeof(FormNodeList), DockState.DockRight) as FormNodeList;
            this.frmNodeList.MindTree = this.currentMindTree;
        }

        private void btnCommandStack_Click(object sender, EventArgs e)
        {
            this.frmCommandStack = this.ShowDockContent(typeof(FormCommandStack), DockState.DockRight) as FormCommandStack;
            this.frmCommandStack.CommandStack = this.currentCommandStack;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (MessageBox.Show("确定要退出程序吗？","确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No);
        }

        
    }
}
