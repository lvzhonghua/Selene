using Selene.BaseControl;
using Selene.BaseControl.Enums;
using Selene.Logical;
using Selene.Model;
using Selene.Providers;
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

namespace Selene.Forms.PartVolume.Style
{
    public partial class StyleEditForm : DataFormBase
    {
        private Genealogy genealogy;

        private GenealogyBLL genealogyBLL;

        public StyleEditForm()
        {
            InitializeComponent();

            genealogyBLL = new GenealogyBLL();
        }

        private void InitStyles()
        {
            var dataList = new StyleProvider().GetDataList();
            this.lbStyles.DataSource = dataList;
            lbStyles.SelectedIndex = dataList.FindIndex(data => data.Selected);
        }

        private void InitManageSx()
        {
            var dataList = new WorldManageNumberProvider().GetDataList();
            this.cbManageSx.DataSource = dataList;
            cbManageSx.SelectedIndex = dataList.FindIndex(data => data.Selected);
        }

        private void InitManageSxt()
        {
            var dataList = new WorldManageNumberProvider().GetDataList();
            this.cbManageSxt.DataSource = dataList;
            cbManageSxt.SelectedIndex = dataList.FindIndex(data => data.Selected);
        }

        private void LoadDefaultGenealogy()
        {
            this.genealogy = genealogyBLL.GetGenealogy();
        }

        private void StyleEditForm_Load(object sender, EventArgs e)
        {
            this.OperatorFormMode = FormMode.Edit;

            InitData();

            LoadDefaultGenealogy();

            this.SetFormModel<Genealogy>("genealogy", this.genealogy);
        }

        private void InitData()
        {
            InitStyles();

            InitManageSx();

            InitManageSxt();

            this.lblInfoOne.Text = "后转式的体例，选择世数时包含后转的那一世。例如：五世一转就要选“6世”，如果只选“5世”的话，就变成了四世一转；";
            this.lblInfoTwo.Text = "每个体例的具体版面格式请到菜单“族谱管理”->“版面设置”中进行设置!";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Genealogy newGenealogy = this.GetFormModel<Genealogy>("genealogy");
            if (genealogyBLL.UpdateGenealogy(newGenealogy))
            {
                this.Close();
            }
            else
            {
                UICommonUtil.MessageBoxShow("保存失败");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
