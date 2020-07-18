﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Doit.MindJet.Tool
{
    public partial class FormMain : Form
    {
        private MindTree currentMindTree = null;
        private FormNodeList frmNodeList = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.dockPanel.Theme = new VS2015LightTheme();

            FormDocument frmDoc = new FormDocument();
            frmDoc.Activated += FrmDoc_Activated;
            frmDoc.Show(this.dockPanel,DockState.Document);
        }

        private void FrmDoc_Activated(object sender, EventArgs e)
        {
            this.currentMindTree = ((FormDocument)sender).MindTree;

            if (this.frmNodeList != null && this.frmNodeList.Visible == true)
            {
                this.frmNodeList.MindTree = this.currentMindTree;
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
    }
}
