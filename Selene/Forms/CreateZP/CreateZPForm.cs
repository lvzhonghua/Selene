using Selene.BaseControl;
using Selene.Logical;
using Selene.Model;
using Selene.Providers;
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
using Selene.Manage;
using Selene.Model.Enums;
using Selene.BaseControl.Enums;

namespace Selene.Forms.CreateZP
{
    public partial class CreateZPForm : DataFormBase
    {

        private Dictionary<int, String> tabDict = new Dictionary<int, string>();
        private LoginForm loginForm;
        Func<string, bool> btnNextEventBefore;

        public CreateZPForm(LoginForm loginForm)
        {
            InitializeComponent();

            new GenealogyNoteKeyHandler(this.rtxtGenealogyNote);

            this.loginForm = loginForm;
            InitData();
        }

        private void InitData()
        {
            tabDict.Add(0, "welcome");
            tabDict.Add(1, "family");
            tabDict.Add(2, "seniority");
            tabDict.Add(3, "workmode");
            tabDict.Add(4, "style");
            tabDict.Add(5, "ancestorSxInfo");
            tabDict.Add(6, "ancestorInfo");
            tabDict.Add(7, "ancestorGenealogyNote");
            tabDict.Add(8, "end");
        }



        private void CreateZP_Load(object sender, EventArgs e)
        {

            BtnStatus();

            LoadLabelInfo();

            btnNextEventBefore += btnNextEventBeforeAction;
        }

        private bool btnNextEventBeforeAction(String tabName)
        {
            bool result = true;
            switch (tabName)
            {
                case "welcome":
                    break;
                case "family":
                    result = CheckFamilyTab();
                    break;
                case "ancestorInfo":
                    result = CheckAncestorInfo();
                    break;
                case "ancestorGenealogyNote":
                    result = CheckInputGenealogyNote();
                    break;
                default:
                    break;
            }
            return result;
        }

        #region 初始化信息
        private void LoadLabelInfo()
        {
            lblHr.Text = "";
            lblHr.Height = 2;
            lblHr.Width = this.Width;
            lblHr.Location = new Point(0, lblHr.Location.Y);

            this.tcMain.Location = new Point(this.tcMain.Location.X, -15);
            this.tcMain.Height += 15;
            this.tcMain.Region = new Region(new RectangleF(this.tabPage1.Left, this.tabPage1.Top, this.tabPage1.Width, this.tabPage1.Height));

            this.lblInfoOne.Text = "炎黄宗谱软件系统是专业修谱人员的专业知识与现代数字化修谱技术的完美结合";
            this.lblInfoTwo.Text = "选择炎黄--不用画线、不用排版、无须专业人员，您就可以轻松、高效地编排出各种样式、各种体例的家谱。原谱式录入、自动生成世系图、速查表、父子页码，专业而又随时可更改的多种版式版面等等一系列功能，使您从以往枯燥繁杂的修谱工作中解脱出来，轻轻松松成为修谱专家！";
            this.lblInfoThree.Text = "现在本向导将一步一步的引导你完成“添加宗谱”工作，请点击“下一步”，按照相应的提示来操作。";

            this.lblInfoFour.Text = "宗谱名称，是给要管理的宗谱命名的一个名字。默认地它会作为宗谱侧边栏上方的标题，如：陈氏宗谱、王氏家谱、文一公支谱等。";

            this.lblInfoFive.Text = "行辈，也成为行第、字辈等。如果自始祖开始的行辈不知道，只知道从某世开始的行辈，请从知道的那一世开始输入。如果不知道行辈或者不希望使用行辈功能，可以直接点“下一步”跳过。";

            this.lblInfoSix.Text = "使用“专业模式”时，需要掌握炎黄宗谱管理系统的数据录入规则。炎黄宗谱里提供的所有功能都可用";

            this.lblGenealogyNoteHintOne.Text = "需要在始祖谱文中输入生子信息(如果老谱中没有注明，请根据其子女的谱名手工加上)，并且要用斜线“/”隔开。如：";
            this.lblGenealogyNoteHintTwo.Text = "生子三/永丰/永庆/庆年/\r\n生女二/适刘/适胡/\r\n嗣子一/爱国/";

            this.lblEndHint.Text = "当您继续点击下面的“完成”按钮时，系统就会创建一个使用默认格式的宗谱，您可以继续在里面录入更多的资料，也可以预览编排出来的效果。如果编排出来的效果不是十分理想，您可以在“宗谱管理”菜单中进行进一步的设置（特别是“版面设置”，软件刚开始时使用的时默认设置，很多具体细节都时这个设置里面完成）。";

            InitStyles();

            InitManageSx();

            InitManageSxt();
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

        #endregion


        private bool CheckInputGenealogyNote()
        {
            if (!UICommonUtil.CheckBirthBody(this.rtxtGenealogyNote))
            {
                UICommonUtil.MessageBoxShow("子女信息输入格式有误");
                return false;
            }
            return true;
        }

        private bool CheckFamilyTab()
        {
            if (String.IsNullOrEmpty(this.txtName.Text))
            {
                UICommonUtil.MessageBoxShow("宗谱名称不能为空");
                return false;
            }

            if (String.IsNullOrEmpty(this.txtFamilyName.Text))
            {
                UICommonUtil.MessageBoxShow("对应姓氏不能为空");
                return false;
            }

            //检测是否存在相同的宗谱名称
            string dbname = string.Format("{0}.db", this.txtName.Text);
            //创建库
            string fullDBName = DBManage.CalcFullDBPath(CommonMessage.data_path, dbname);
            if (File.Exists(fullDBName))
            {
                UICommonUtil.MessageBoxShow("已经存在相同的宗谱");
                return false;
            }

            return true;
        }

        private bool CheckAncestorInfo()
        {
            if (String.IsNullOrEmpty(this.txtAncestorParentInfo.Text))
            {
                UICommonUtil.MessageBoxShow("始祖父辈信息不能为空");
                return false;
            }
            if (String.IsNullOrEmpty(this.txtAncestorWorldNumber.Text))
            {
                UICommonUtil.MessageBoxShow("始祖的世数不能为空");
                return false;
            }
            if (String.IsNullOrEmpty(this.txtAncestorGenealogyName.Text))
            {
                UICommonUtil.MessageBoxShow("始祖的谱名不能为空");
                return false;
            }
            return true;
        }

        private void BtnStatus()
        {
            if (this.tcMain.SelectedIndex == 0)
            {
                btnUp.Enabled = false;
            }
            else
            {
                btnUp.Enabled = true;
            }
            if (this.tcMain.SelectedIndex == this.tcMain.TabCount - 1)
            {
                btnNext.Text = "完成";
            }
            else
            {
                btnNext.Text = "下一步";
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            this.tcMain.SelectTab(--this.tcMain.SelectedIndex);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ("完成".Equals(btnNext.Text))
            {
                SaveGenealogy();
                return;
            }
            if (btnNextEventBefore != null)
            {
                //如果返回的是false则不执行下一步
                if (!btnNextEventBefore(tabDict[this.tcMain.SelectedIndex]))
                {
                    return;
                }
            }

            this.tcMain.SelectTab(++this.tcMain.SelectedIndex);
        }

        private void SaveGenealogy()
        {
            Genealogy genealogy = GetFormModel<Genealogy>("genealogy");
            Lineage lineage = GetFormModel<Lineage>("lineage");

            Clansman clansman = GetFormModel<Clansman>("clansman");
            clansman.Pid = -1;
            clansman.OwnType = ChildrenType.ancestor;

            string dbname = string.Format("{0}.db", genealogy.Name);
            //创建库
            DBManage.CreateOrOpenDBAndInit(CommonMessage.data_path, dbname);

            if (new GenealogyBLL().SaveGenealogy(genealogy, clansman, lineage))
            {
                this.Close();
                loginForm.Show();
                loginForm.LoadGenealogy();
            }
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnStatus();
        }

        private void CreateZP_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Show();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            string name = this.txtName.Text;
            if (String.IsNullOrEmpty(name))
            {
                return;
            }

            if (name.IndexOf("氏宗谱") > 0)
            {
                this.txtFamilyName.Text = name.Replace("氏宗谱", "");
            }
        }

        private void rtxtGenealogyNote_TextChanged(object sender, EventArgs e)
        {
            UICommonUtil.CheckBirthBody(this.rtxtGenealogyNote);
        }
    }
}
