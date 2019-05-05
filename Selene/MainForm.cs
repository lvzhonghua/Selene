using Selene.Forms;
using Selene.Forms.GenealogyInfo;
using Selene.Forms.LineageInfo;
using Selene.Forms.PreambleInfo;
using Selene.Forms.PrintPreview;
using Selene.Forms.PartVolume;
using Selene.Forms.PartVolume.Style;
using Selene.Forms.Tools;
using Selene.Logical;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene
{
    public partial class MainForm : Form
    {
        private DBListItem currentDBListItem;

        private LoginForm loginForm;

        private bool applicationExist = true;

        string oldFormTitle = "";

        public MainForm(DBListItem dbListItem)
        {
            this.currentDBListItem = dbListItem;
            DBManage.SetSqliteDBPath(dbListItem.Path);
            InitializeComponent();
        }

        public void SetLoginForm(LoginForm loginForm)
        {
            this.loginForm = loginForm;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            oldFormTitle = this.Text;
            InitForm();

            OpenGenealogyAddForm();
        }


        private void InitForm()
        {
            this.Location = new Point(0, 0);
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            this.Text = oldFormTitle + string.Format("【{0}】", currentDBListItem.Name);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (applicationExist)
            {
                Application.Exit();
            }

        }

        private void tsbAddInfo_Click(object sender, EventArgs e)
        {
            OpenGenealogyAddForm();
        }

        private void OpenGenealogyAddForm()
        {
            ClansmanAddForm genealogyAddForm = new ClansmanAddForm();
            genealogyAddForm.MdiParent = this;
            genealogyAddForm.Show();
        }

        private void tsmiDataTool_Click(object sender, EventArgs e)
        {
            DBToolForm dbToolForm = new DBToolForm();
            dbToolForm.ShowDialog();
        }

        private void tsmiSwitchGenealogy_Click(object sender, EventArgs e)
        {
            SwitchGenealogy();
        }

        public void SwitchGenealogy()
        {
            loginForm.Show();
            loginForm.LoadGenealogy();
            applicationExist = false;
            this.Close();
        }

        private void tsmiAddGenealogy_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            loginForm.CreateGenealogy();
            applicationExist = false;
            this.Close();
        }

        private void tsmiLayoutSetting_Click(object sender, EventArgs e)
        {
            OpenLayoutSetting();
        }

        private void tsbLayoutSetting_Click(object sender, EventArgs e)
        {
            OpenLayoutSetting();
        }

        private void OpenLayoutSetting()
        {
            LayoutSettingForm layoutSettingForm = new LayoutSettingForm();
            layoutSettingForm.ShowDialog();
        }

        private void tsmiCopyGenealogySetting_Click(object sender, EventArgs e)
        {
            CopyGenealogySettingForm copyGenealogySettingForm = new CopyGenealogySettingForm(currentDBListItem);
            copyGenealogySettingForm.ShowDialog();
        }

        private void tsbPartVolumeSetting_Click(object sender, EventArgs e)
        {
            OpenPartVolumeSetting();
        }

        private void tsmiPartVolumeSetting_Click(object sender, EventArgs e)
        {
            OpenPartVolumeSetting();
        }

        private void OpenPartVolumeSetting()
        {
            PartVolumeSettingForm partVolumeSettingForm = new PartVolumeSettingForm();
            partVolumeSettingForm.ShowDialog();
        }

        private void tsbPreambleManage_Click(object sender, EventArgs e)
        {
            PreambleManageForm preambleManageForm = new PreambleManageForm();
            preambleManageForm.ShowDialog();
        }

        private void tsbPrintPreview_Click(object sender, EventArgs e)
        {
            PrintPreviewSelectForm printPreviewSelectForm = new PrintPreviewSelectForm();
            printPreviewSelectForm.ShowDialog();
        }

        private void tsmiPageSetupSetting_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.ShowDialog();
        }

        private void tsmiLineageManage_Click(object sender, EventArgs e)
        {
            LineageManageForm lineageManageForm = new LineageManageForm();
            lineageManageForm.ShowDialog();
        }

        private void tsmiEditGenealogy_Click(object sender, EventArgs e)
        {
            GenealogyEditForm genealogyEditForm = new GenealogyEditForm();
            genealogyEditForm.SetMainForm(this);
            genealogyEditForm.ShowDialog();
        }

        private void tsmiStyleEdit_Click(object sender, EventArgs e)
        {
            StyleEditForm styleEditForm = new StyleEditForm();
            styleEditForm.ShowDialog();
        }
    }
}
