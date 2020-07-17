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

namespace Doit.MindJet.Tool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.dockPanel.Theme = new VS2015LightTheme();

            FormDocument frmDoc = new FormDocument();
            frmDoc.Show(this.dockPanel,DockState.Document);

        }
    }
}
