using Selene.BaseControl;
using Selene.BaseControl.Enums;
using Selene.Logical;
using Selene.Logical.Message;
using Selene.Logical.ViewModel;
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

namespace Selene.Forms.GenealogyInfo
{
    public partial class ClansmanDetailedForm : DataFormBase
    {
        private Clansman clansman;
        private ClansmanBLL clansmanBLL;
        private ClansmanAddForm genealogyAddForm;

        public ClansmanDetailedForm(Clansman clansman)
        {
            InitializeComponent();

            this.clansman = clansman;

            new GenealogyNoteKeyHandler(this.rtxtGenealogyNote,this.cbkNumberToChina,this.cbkWriteSpace);

            this.clansmanBLL = new ClansmanBLL();
        }

        public void SetGenealogyAddForm(ClansmanAddForm genealogyAddForm)
        {
            this.genealogyAddForm = genealogyAddForm;
        }

        private void ClansmanDetailedForm_Load(object sender, EventArgs e)
        {
            this.OperatorFormMode = FormMode.Edit;

            this.SetFormModel<Clansman>(this.clansman);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtxtGenealogyNote_TextChanged(object sender, EventArgs e)
        {
            UICommonUtil.CheckBirthBody(this.rtxtGenealogyNote);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool genealogyNoteInput=UICommonUtil.CheckBirthBody(this.rtxtGenealogyNote);
            if (!genealogyNoteInput)
            {
                UICommonUtil.MessageBoxShow("谱文输入格式有误");
                return;
            }

            if (SaveClansman())
            {
                genealogyAddForm.ReloadFamilyTree();
                this.Close();
            }
        }

        private bool SaveClansman()
        {
            string genealogyNote = this.rtxtGenealogyNote.Text;
            if (string.IsNullOrEmpty(genealogyNote))
            {
                return false;
            }

            Clansman clansman=GetFormModel<Clansman>();

            ReturnMessage rm = clansmanBLL.UpdateClansman(clansman);
            if (!rm.Ok)
            {
                UICommonUtil.MessageBoxShow(rm.Message);
            }
            return rm.Ok;
        }
        
    }
}
