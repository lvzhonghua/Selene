using Selene.BaseControl;
using Selene.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Forms.PrintPreview
{
    public partial class PrintPreviewSelectForm : FormBase
    {
        public PrintPreviewSelectForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PrintPreviewMainForm printPreivewMainForm = new PrintPreviewMainForm();
            printPreivewMainForm.ShowDialog();
        }

        private void PrintPreviewSelectForm_Load(object sender, EventArgs e)
        {
            this.dcboPartVolume.DataSource = new VolumeProvider().GetDataList();
        }
    }
}
