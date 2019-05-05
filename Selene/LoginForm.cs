using Selene.Forms;
using Selene.Forms.CreateZP;
using Selene.Manage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Selene
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateGenealogy();
        }

        public void CreateGenealogy()
        {
            CreateZPForm createZP = new CreateZPForm(this);
            createZP.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.cboGenealogys.DisplayMember = "Name";
            this.cboGenealogys.ValueMember = "Path";

            LoadGenealogy();
        }

        public void LoadGenealogy()
        {
            var dataList = GetLocalDBInfo();
            this.cboGenealogys.DataSource = dataList;
        }

        private List<DBListItem> GetLocalDBInfo()
        {
            string[] dbs = Directory.GetFiles(CommonMessage.data_path, "*.db");

            return dbs.Select(db => { return new DBListItem(db); }).ToList();
        }


        private void btnDBTool_Click(object sender, EventArgs e)
        {
            DBToolForm dbToolForm = new DBToolForm();
            dbToolForm.Show();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.cboGenealogys.SelectedValue==null)
            {
                MessageBox.Show("请选择一个族谱后在进入，如果没有族谱可选，请点击“添加族谱”","炎黄宗谱");
                return;
            }
            DBListItem dbListItem= this.cboGenealogys.SelectedItem as DBListItem;
            if (dbListItem == null)
            {
                MessageBox.Show("程序异常请与管理员联系-loginform-btnok", "炎黄宗谱");
                return;
            }
            MainForm mf = new MainForm(dbListItem);
            mf.SetLoginForm(this);
            mf.Show();
            this.Hide();
        }
    }
}
