using Selene.BaseControl;
using Selene.BaseControl.Enums;
using Selene.Forms.Setting.Catalogue;
using Selene.Forms.Setting.Conventional;
using Selene.Forms.Setting.HFStyle;
using Selene.Forms.Setting.LMStyle;
using Selene.Logical;
using Selene.Model.Enums;
using Selene.Model.SettingModel;
using Selene.Model.SettingModel.Book;
using Selene.Model.SettingModel.Book.HFStyle;
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

namespace Selene.Forms.PartVolume
{
    public partial class LayoutSettingForm : DataFormBase
    {
        private List<BaseSettingCtrl> settingCtrls;
        private Dictionary<string, Type> tabOfCtrls;
        private Dictionary<string, Size> tabSizeDict;
        private Size defaultSize;

        public LayoutSettingForm()
        {
            InitializeComponent();

            settingCtrls = new List<BaseSettingCtrl>();
            tabOfCtrls = new Dictionary<string, Type>();
            tabSizeDict = new Dictionary<string, Size>();

            InitTabCtrl();
        }

        private void InitTabCtrl()
        {
            tabOfCtrls.Add("tpHeaderFooter", typeof(HeaderFooterStyleCtrl));
            tabOfCtrls.Add("tpConventionalSetting", typeof(ConventionalSettingCtrl));
            tabOfCtrls.Add("tpCatalogueSetting", typeof(CatalogueSettingCtrl));
            tabOfCtrls.Add("tpLineageMapStyle", typeof(LineageMapStyleCtrl));

            tabSizeDict.Add("tpHeaderFooter", new Size(this.Size.Width + 200, this.Size.Height));
        }



        private void LayoutSettingForm_Load(object sender, EventArgs e)
        {
            this.OperatorFormMode = FormMode.Edit;

            LoadTabPageCrtl(0);

            defaultSize = this.Size;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (var ctrl in settingCtrls)
            {
                result = ctrl.CloseEvent();
                if (!result)
                {
                    break;
                }
            }
            if (result)
            {
                this.Close();
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (var ctrl in settingCtrls)
            {
                result = ctrl.SaveEvent();
                if (!result)
                {
                    break;
                }
            }
            if (result)
            {
                this.Close();
            }
        }

        private void LoadTabPageCrtl(string tabName)
        {
            if (!tcMain.TabPages.ContainsKey(tabName))
            {
                return;
            }
            TabPage tabPage = tcMain.TabPages[tabName];
            LoadTabPageCrtl(tabPage);
        }

        private void LoadTabPageCrtl(int tabIndex)
        {
            if (tabIndex >= tcMain.TabPages.Count)
            {
                return;
            }
            TabPage tabPage = tcMain.TabPages[tabIndex];
            LoadTabPageCrtl(tabPage);
        }

        private void LoadTabPageCrtl(TabPage tabPage)
        {
            if (tabPage.Controls.Count == 0 && tabOfCtrls.ContainsKey(tabPage.Name))
            {
                Type ctrlType = tabOfCtrls[tcMain.SelectedTab.Name];
                var ctrl = Activator.CreateInstance(ctrlType) as BaseSettingCtrl;

                tcMain.SelectedTab.Controls.Add(ctrl);
                settingCtrls.Add(ctrl);
            }
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTabPageCrtl(tcMain.SelectedTab);

            if (tabSizeDict.ContainsKey(tcMain.SelectedTab.Name))
            {
                this.Size = tabSizeDict[tcMain.SelectedTab.Name];
            }
            else
            {
                this.Size = defaultSize;
            }
            
        }
    }
}
