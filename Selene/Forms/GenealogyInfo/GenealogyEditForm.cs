using Selene.BaseControl;
using Selene.BaseControl.Enums;
using Selene.Logical;
using Selene.Manage;
using Selene.Model;
using Selene.UIUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Forms.GenealogyInfo
{
    public partial class GenealogyEditForm : DataFormBase
    {
        private Genealogy genealogy;

        private GenealogyBLL genealogyBLL;

        private string oldName;

        private MainForm mainForm;

        public void SetMainForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public GenealogyEditForm()
        {
            InitializeComponent();

            genealogyBLL = new GenealogyBLL();

            LoadDefaultGenealogy();
        }

        private void GenealogyEditForm_Load(object sender, EventArgs e)
        {
            this.OperatorFormMode = FormMode.Edit;
            this.SetFormModel<Genealogy>("genealogy", genealogy);
        }

        private void LoadDefaultGenealogy()
        {
            this.genealogy = genealogyBLL.GetGenealogy();
            this.oldName = genealogy.Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (!CheckGenealogySave())
            {
                return;
            }

            Genealogy genealogy = this.GetFormModel<Genealogy>("genealogy");
            if (genealogyBLL.UpdateGenealogy(genealogy))
            {
                if (!oldName.Equals(this.genealogy))
                {
                    string newDbName=string.Format("{0}.db",genealogy.Name);
                    string oldDbFullName = DBManage.CalcFullDBPath(CommonMessage.data_path, string.Format("{0}.db", oldName));
                    string newDbFullName=DBManage.CalcFullDBPath(CommonMessage.data_path,newDbName);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    File.Move(oldDbFullName,newDbFullName);
                    DBManage.SetSqliteDBPath(newDbFullName);

                    if (mainForm != null)
                    {
                        mainForm.SwitchGenealogy();
                    }
                }

                this.Close();
            }
            else
            {
                UICommonUtil.MessageBoxShow("保存失败");
            }
        }

        private bool CheckGenealogySave()
        {
            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                UICommonUtil.MessageBoxShow("宗谱名称不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtFamilyName.Text))
            {
                UICommonUtil.MessageBoxShow("姓氏名称不能为空");
                return false;
            }
            return true;
        }
    }
}
