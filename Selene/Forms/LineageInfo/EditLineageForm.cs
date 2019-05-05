using Selene.BaseControl.PropertyExtend;
using Selene.Logical;
using Selene.Model;
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

namespace Selene.Forms.LineageInfo
{
    public partial class EditLineageForm : Form
    {
        private Lineage lineage;
        private LineageBLL lineageBLL;
        private LineageManageForm lineageManageForm;
        public EditLineageForm(Lineage lineage)
        {
            InitializeComponent();
            this.lineage = lineage;
            this.lineageBLL = new LineageBLL();
        }

        public void SetLineageManageForm(LineageManageForm lineageManageForm)
        {
            this.lineageManageForm = lineageManageForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditLineageForm_Load(object sender, EventArgs e)
        {
            var obj = PropertyGridUtil.GetObject<Lineage>(lineage);
            this.pgLineage.SelectedObject = obj;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var lineage = PropertyGridUtil.GridObject2Model<Lineage>(this.pgLineage.SelectedObject);

            if (lineageBLL.UpdateLineageRtnBool(lineage))
            {
                if (lineageManageForm != null)
                {
                    lineageManageForm.LoadLineageListView();
                }
                this.Close();
            }
            else
            {
                UICommonUtil.MessageBoxShow("世系保存出错");
            }
        }

        
    }
}
