using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Selene.BaseControl;
using Selene.Logical;
using Selene.Model.SettingModel.Book;
using Selene.UIUtils;

namespace Selene.Forms.Setting.Catalogue
{
    public partial class CatalogueSettingCtrl : BaseSettingCtrl
    {
        private Dictionary<string, DataTextBox> setFontTextBoxs = new Dictionary<string, DataTextBox>();

        private CommonSettingBLL commonSettingBLL;
        private CheatSheetsSetting cheatSheetsSetting;

        public CatalogueSettingCtrl()
        {
            InitializeComponent();

            commonSettingBLL = new CommonSettingBLL();

            setFontTextBoxs.Add("categoryTitleFont", this.dtxtCategoryTitleFont);
            setFontTextBoxs.Add("categoryContentFont", this.dtxtCategoryContentFont);
            setFontTextBoxs.Add("cheatSheetsTitleFont", this.dtxtCheatSheetsTitleFont);
            setFontTextBoxs.Add("cheatSheetsContentFont", this.dtxtCheatSheetsContentFont);
        }

        private void SetCheatSheetsSetting()
        {
            cheatSheetsSetting = commonSettingBLL.GetCheatSheetsSetting();
            this.SetFormModel<CheatSheetsSetting>(CommonSettingBLL.CheatSheetsSettingKey, commonSettingBLL.GetCheatSheetsSetting());
        }

        private void lblCommonSetFont_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) { return; }

            setFont(setFontTextBoxs[lbl.Tag.ToString()]);
        }

        private void txtCommonSetFont_Click(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) { return; }

            setFont(setFontTextBoxs[txt.Tag.ToString()]);
        }

        private void setFont(DataTextBox txtSetFont)
        {
            FontDialog fd = new FontDialog();
            fd.ShowEffects = false;
            fd.AllowSimulations = false;
            fd.AllowVectorFonts = false;
            fd.AllowScriptChange = false;

            if (!string.IsNullOrEmpty(txtSetFont.Text))
            {
                string[] fonts = txtSetFont.Text.Split(',');
                fd.Font = new Font(fonts[0], float.Parse(fonts[1]));
            }


            if (DialogResult.OK == fd.ShowDialog())
            {
                txtSetFont.Text = fd.Font.Name + "," + fd.Font.Size;
            }
        }

        public override bool SaveEvent()
        {
            return SaveCheatSheetsSetting();
        }

        private bool SaveCheatSheetsSetting()
        {
            CheatSheetsSetting cheatSheetsSetting = this.GetFormModel<CheatSheetsSetting>(CommonSettingBLL.CheatSheetsSettingKey);

            if (commonSettingBLL.SaveCheatSheetsSetting(cheatSheetsSetting))
            {
                return true;
            }
            else
            {
                UICommonUtil.MessageBoxShow("版式设置，保存失败");
                return false;
            }
        }

        private void CatalogueSettingCtrl_Load(object sender, EventArgs e)
        {
            SetCheatSheetsSetting();
        }
    }
}
